using Application.Interfaces;
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
        private readonly IExtractGovWebDataRepository _extractGovWebData;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly HttpClient _httpClient;

        public ExtractGovWebDataService(IExtractGovWebDataRepository extractGovWebData, HttpClient httpClient, IHostingEnvironment hostingEnvironment)
        {
            _extractGovWebData = extractGovWebData;
            _httpClient = httpClient;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> GetGovData(string searchTerm)
        {
            List<string> links = await SearchLinksRelated(searchTerm);
            List<GovInformation> informations = await ExtractInfoGov(links);

            return await _extractGovWebData.SaveExtractGovData(informations);
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

        private async Task<List<GovInformation>> ExtractInfoGov(List<string> links)
        {
            List<GovInformation> informations = new();

            foreach (string link in links)
            {
                string htmlResponse = await _httpClient.GetResponseHtmlAsync(link);

                List<DownloadUrlDocument> completeDownloadPaths = await ExtractDocumentsFiles(htmlResponse);
                Root root = await DownloadMetadataInfo(htmlResponse);

                informations.Add(new GovInformation() { Root = root, CompleteDownloadPaths = completeDownloadPaths });
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
                        completeDownloadPaths.Add(new() { Url = pathDownload });
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
    }
}