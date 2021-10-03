using Newtonsoft.Json;

namespace Domain.Models
{
    public class ContactPoint : BaseEntity
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        public string Fn { get; set; }
        public string HasEmail { get; set; }
    }
}