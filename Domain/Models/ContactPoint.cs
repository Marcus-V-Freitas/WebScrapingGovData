using Newtonsoft.Json;

namespace Domain.Models
{
    public class ContactPoint
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        public string fn { get; set; }
        public string hasEmail { get; set; }
    }
}