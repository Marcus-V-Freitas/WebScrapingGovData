using Newtonsoft.Json;

namespace Domain.Models
{
    public class ContactPoint : BaseEntity
    {
        [JsonProperty("@type")]
        public string Type { get; private set; }

        public string Fn { get; private set; }
        public string HasEmail { get; private set; }
    }
}