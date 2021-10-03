using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Models
{
    public class WebClientCrawler : WebClient
    {
        //10 secs default
        public int Timeout { get; set; } = 10000;

        protected override WebRequest GetWebRequest(Uri uri)
        {
            var webClient = base.GetWebRequest(uri);
            webClient.Timeout = Timeout;
            return webClient;
        }

        public new async Task<string> DownloadStringTaskAsync(Uri url)
        {
            var download = base.DownloadStringTaskAsync(url);
            if (await Task.WhenAny(download, Task.Delay(Timeout)) != download)
            {
                CancelAsync();
            }
            return await download;
        }
    }
}