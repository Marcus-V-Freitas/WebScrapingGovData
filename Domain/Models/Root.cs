using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Root : BaseEntity
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        public string AccessLevel { get; set; }
        public IEnumerable<string> BureauCode { get; set; }
        public ContactPoint ContactPoint { get; set; }
        public IEnumerable<Distribution> Distribution { get; set; }
        public string Identifier { get; set; }
        public string Issued { get; set; }
        public IEnumerable<string> Keyword { get; set; }
        public string LandingPage { get; set; }
        public string License { get; set; }
        public IEnumerable<string> ProgramCode { get; set; }
        public Publisher Publisher { get; set; }
        public string Temporal { get; set; }

        public string ItemType { get; set; }
        public string ProxyFilter { get; set; }
        public string Culture { get; set; }
        public string Owner { get; set; }
        public string Guid { get; set; }
        public IEnumerable<string> Screenshots { get; set; }
        public string Id { get; set; }
        public int Size { get; set; }
        public IEnumerable<string> AppCategories { get; set; }
        public string Access { get; set; }
        public int AvgRating { get; set; }
        public string Title { get; set; }
        public string GroupDesignations { get; set; }
        public int NumRatings { get; set; }
        public int NumComments { get; set; }
        public string Snippet { get; set; }
        public bool IEnumerableed { get; set; }
        public string LargeThumbnail { get; set; }

        public string Thumbnail { get; set; }
        public long Uploaded { get; set; }
        public IEnumerable<string> Industries { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> TypeKeywords { get; set; }
        public IEnumerable<string> Extent { get; set; }
        public string ContentOrigin { get; set; }
        public int SubInfo { get; set; }
        public int ScoreCompleteness { get; set; }
        public string Banner { get; set; }
        public string Properties { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string Name { get; set; }
        public string LicenseInfo { get; set; }
        public IEnumerable<string> Languages { get; set; }
        public string Url { get; set; }
        public string LastModified { get; set; }
        public string Documentation { get; set; }
        public string Modified { get; set; }
        public string SpatialReference { get; set; }
        public string Item { get; set; }
        public int NumViews { get; set; }
        public string AccessInformation { get; set; }
    }
}