using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Common.ExtensionMethods;
using Domain.Interfaces;
using Domain.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExtractGovWebDataService : IExtractGovWebDataService
    {
        private readonly string _baseUrl = "https://catalog.data.gov/";
        private readonly IExtractGovWebDataRepository _extractGovWebDataRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ExtractGovWebDataService(IExtractGovWebDataRepository extractGovWebDataRepository,
                                        IHostingEnvironment hostingEnvironment,
                                        IMapper mapper,
                                        HttpClient httpClient)
        {
            _extractGovWebDataRepository = extractGovWebDataRepository;
            _httpClient = httpClient;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public async Task<bool> ExtractGovFilesAndData(string searchTerm)
        {
            List<string> links = await SearchLinksRelated(searchTerm);
            List<GovInformation> informations = await ExtractInfoGov(links, searchTerm);

            return await _extractGovWebDataRepository.SaveExtractGovData(informations);
        }

        private async Task<List<string>> SearchLinksRelated(string searchTerm)
        {
            List<string> links = new();
            string htmlResponse = await _httpClient.GetResponseHtmlAsync(_baseUrl.CombineUrl($"dataset?q={searchTerm}&sort=score+desc"));

            HtmlDocument doc = htmlResponse.CreateHtmlDocument();
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(".//h3//a");

            if (nodes != null)
                links = nodes.Select(node => _baseUrl.CombineUrl(node.Attributes["href"].Value)).ToList();

            return links;
        }

        private async Task<List<GovInformation>> ExtractInfoGov(List<string> links, string searchTerm)
        {
            List<GovInformation> informations = new();

            foreach (string link in links)
            {
                string htmlResponse = await _httpClient.GetResponseHtmlAsync(link);

                List<DownloadUrlDocument> completeDownloadPaths = await ExtractDocumentsFiles(htmlResponse);
                Root root = await DownloadMetadataInfo(htmlResponse);

                informations.Add(new GovInformation(root, searchTerm, completeDownloadPaths));
            }

            return informations;
        }

        private async Task<List<DownloadUrlDocument>> ExtractDocumentsFiles(string htmlResponse)
        {
            List<DownloadUrlDocument> completeDownloadPaths = new();
            HtmlDocument doc = htmlResponse.CreateHtmlDocument();
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//ul[@class='resource-list']/li/a");

            if (nodes != null)
            {
                List<string> links = nodes.Select(node => _baseUrl.CombineUrl(node.Attributes["href"].Value)).ToList();

                foreach (string link in links)
                {
                    string pathDownload = await DownloadFiles(link);
                    if (!string.IsNullOrEmpty(pathDownload))
                    {
                        completeDownloadPaths.Add(new(pathDownload));
                    }
                }
            }

            return completeDownloadPaths;
        }

        private async Task<string> DownloadFiles(string link)
        {
            string completeDownloadPath = string.Empty;

            string htmlResponse = await _httpClient.GetResponseHtmlAsync(link);

            HtmlDocument doc = htmlResponse.CreateHtmlDocument();
            HtmlNode node = doc.DocumentNode.SelectSingleNode(".//div[@class='actions']//ul//li//a");

            if (node != null)
            {
                string linkDoc = node.Attributes["href"].Value;
                completeDownloadPath = linkDoc.DownloadFilesFromUrl(Path.Combine(_hostingEnvironment.WebRootPath, "Files"), true);
            }

            return completeDownloadPath;
        }

        private async Task<Root> DownloadMetadataInfo(string htmlResponse)
        {
            Root root = new();
            HtmlDocument doc = htmlResponse.CreateHtmlDocument();
            HtmlNode node = doc.DocumentNode.SelectSingleNode(".//p[@class='description']//a");

            if (node != null)
            {
                string linkMetadata = node.Attributes["href"].Value;
                string jsonData = await _httpClient.GetResponseHtmlAsync(_baseUrl.CombineUrl(linkMetadata));

                if (jsonData.IsValidJson())
                    root = JsonConvert.DeserializeObject<Root>(jsonData);
            }
            return root;
        }

        public async Task<List<GovInformationDTO>> GetExtractGovDataBySearchTerm(string searchTerm)
        {
            List<GovInformation> govInformations = await _extractGovWebDataRepository.GetExtractGovDataBySearchTerm(searchTerm);

            return _mapper.Map<List<GovInformationDTO>>(govInformations);
        }
    }
}