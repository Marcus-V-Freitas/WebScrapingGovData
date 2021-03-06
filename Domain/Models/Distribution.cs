using Newtonsoft.Json;

namespace Domain.Models
{
    public class Distribution : BaseEntity
    {
        [JsonProperty("@type")]
        public string Type { get; private set; }

        public string DownloadURL { get; private set; }
        public string MediaType { get; private set; }
    }
}