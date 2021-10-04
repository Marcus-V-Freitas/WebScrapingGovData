namespace Domain.Models
{
    public class DownloadUrlDocument : BaseEntity
    {
        public string Url { get; private set; }

        public DownloadUrlDocument(string url)
        {
            Url = url;
        }
    }
}