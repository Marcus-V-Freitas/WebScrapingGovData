using Newtonsoft.Json;

namespace Domain.Models
{
    public class Publisher
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        public string name { get; set; }
    }
}