using Newtonsoft.Json;

namespace Domain.Models
{
    public class Distribution : BaseEntity
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        public string DownloadURL { get; set; }
        public string MediaType { get; set; }
    }
}