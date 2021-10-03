using Newtonsoft.Json;

namespace Domain.Models
{
    public class Publisher : BaseEntity
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        public string Name { get; set; }
    }
}