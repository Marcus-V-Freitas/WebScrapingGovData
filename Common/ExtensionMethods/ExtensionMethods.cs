using Common.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string CombineUrl(this string baseUrl, string relativeUrl)
        {
            UriBuilder baseUri = new UriBuilder(baseUrl);
            Uri newUri;

            if (Uri.TryCreate(baseUri.Uri, relativeUrl, out newUri))
                return newUri.ToString();
            else
                throw new ArgumentException("Unable to combine specified url values");
        }

        public static async Task<string> GetResponseHtmlAsync(this HttpClient httpClient, string url)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine($"Error occurred, the status code is: {responseMessage.StatusCode}");
                return string.Empty;
            }
        }

        public static HtmlDocument CreateHtmlDocument(this string htmlResponse)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.OptionAutoCloseOnEnd = true;
            doc.LoadHtml(htmlResponse);
            return doc;
        }

        public static string GetFileNameFromUrl(this string url)
        {
            Uri uri = new(url);
            string filename = Path.GetFileName(uri.LocalPath);

            if (filename.Contains("?"))
                filename = filename.Substring(0, filename.IndexOf("?"));

            return filename;
        }

        public static string DownloadFilesFromUrl(this string url, string pathSave, bool folderTypeFile = false)
        {
            string completeDownloadPath = string.Empty;

            try
            {
                using (WebClientCrawler webClient = new WebClientCrawler())
                {
                    webClient.Timeout = 10;
                    string folderType = string.Empty;
                    string filename = url.GetFileNameFromUrl();

                    if (folderTypeFile)
                        folderType = Path.GetExtension(filename).Replace(".", "");

                    if (folderTypeFile && string.IsNullOrEmpty(folderType))
                        folderType = "Others";

                    CreateDirectoryIfNotExists(Path.Combine(pathSave, folderType));

                    completeDownloadPath = Path.Combine(pathSave, folderType, $"{Guid.NewGuid()}.{folderType}");

                    if (!File.Exists(completeDownloadPath))
                        webClient.DownloadFile(url, completeDownloadPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                completeDownloadPath = string.Empty;
            }
            return completeDownloadPath;
        }

        public static void CreateDirectoryIfNotExists(this string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static bool IsValidJson(this string json)
        {
            if (string.IsNullOrWhiteSpace(json)) { return false; }
            json = json.Trim();
            if ((json.StartsWith("{") && json.EndsWith("}")) || //For object
                (json.StartsWith("[") && json.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(json);
                    return true;
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}