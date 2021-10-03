using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Root
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        public string accessLevel { get; set; }
        public List<string> bureauCode { get; set; }
        public ContactPoint contactPoint { get; set; }
        public List<Distribution> distribution { get; set; }
        public string identifier { get; set; }
        public string issued { get; set; }
        public List<string> keyword { get; set; }
        public string landingPage { get; set; }
        public string license { get; set; }
        public List<string> programCode { get; set; }
        public Publisher publisher { get; set; }
        public string temporal { get; set; }

        public string itemType { get; set; }
        public object proxyFilter { get; set; }
        public string culture { get; set; }
        public string owner { get; set; }
        public object guid { get; set; }
        public List<object> screenshots { get; set; }
        public string id { get; set; }
        public int size { get; set; }
        public List<object> appCategories { get; set; }
        public string access { get; set; }
        public int avgRating { get; set; }
        public string title { get; set; }
        public object groupDesignations { get; set; }
        public int numRatings { get; set; }
        public int numComments { get; set; }
        public string snippet { get; set; }
        public bool listed { get; set; }
        public object largeThumbnail { get; set; }
        public string type { get; set; }
        public string thumbnail { get; set; }
        public long uploaded { get; set; }
        public List<object> industries { get; set; }
        public string description { get; set; }
        public List<string> tags { get; set; }
        public List<string> typeKeywords { get; set; }
        public List<object> extent { get; set; }
        public string contentOrigin { get; set; }
        public int subInfo { get; set; }
        public int scoreCompleteness { get; set; }
        public object banner { get; set; }
        public object properties { get; set; }
        public List<object> categories { get; set; }
        public object name { get; set; }
        public object licenseInfo { get; set; }
        public List<object> languages { get; set; }
        public string url { get; set; }
        public string lastModified { get; set; }
        public object documentation { get; set; }
        public string modified { get; set; }
        public object spatialReference { get; set; }
        public string item { get; set; }
        public int numViews { get; set; }
        public object accessInformation { get; set; }
    }
}