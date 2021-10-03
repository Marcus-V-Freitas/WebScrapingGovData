using Newtonsoft.Json;

namespace Domain.Models
{
    public class Distribution
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        public string downloadURL { get; set; }
        public string mediaType { get; set; }
    }
}