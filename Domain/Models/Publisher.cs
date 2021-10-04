using Newtonsoft.Json;

namespace Domain.Models
{
    public class Publisher : BaseEntity
    {
        [JsonProperty("@type")]
        public string Type { get; private set; }

        public string Name { get; private set; }
    }
}