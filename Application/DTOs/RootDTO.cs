using System.Collections.Generic;

namespace Application.DTOs
{
    public class RootDTO : BaseEntityDTO
    {
        public string Type { get; private set; }

        public string AccessLevel { get; private set; }
        public IEnumerable<string> BureauCode { get; private set; }
        public ContactPointDTO ContactPoint { get; private set; }
        public IEnumerable<DistributionDTO> Distribution { get; private set; }
        public string Identifier { get; private set; }
        public string Issued { get; private set; }
        public IEnumerable<string> Keyword { get; private set; }
        public string LandingPage { get; private set; }
        public string License { get; private set; }
        public IEnumerable<string> ProgramCode { get; private set; }
        public PublisherDTO Publisher { get; private set; }
        public string Temporal { get; private set; }

        public string ItemType { get; private set; }
        public string ProxyFilter { get; private set; }
        public string Culture { get; private set; }
        public string Owner { get; private set; }
        public string Guid { get; private set; }
        public IEnumerable<string> Screenshots { get; private set; }
        public string Id { get; private set; }
        public int Size { get; private set; }
        public IEnumerable<string> AppCategories { get; private set; }
        public string Access { get; private set; }
        public int AvgRating { get; private set; }
        public string Title { get; private set; }
        public string GroupDesignations { get; private set; }
        public int NumRatings { get; private set; }
        public int NumComments { get; private set; }
        public string Snippet { get; private set; }
        public bool IEnumerableed { get; private set; }
        public string LargeThumbnail { get; private set; }

        public string Thumbnail { get; private set; }
        public long Uploaded { get; private set; }
        public IEnumerable<string> Industries { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<string> Tags { get; private set; }
        public IEnumerable<string> TypeKeywords { get; private set; }
        public IEnumerable<string> Extent { get; private set; }
        public string ContentOrigin { get; private set; }
        public int SubInfo { get; private set; }
        public int ScoreCompleteness { get; private set; }
        public string Banner { get; private set; }
        public string Properties { get; private set; }
        public IEnumerable<string> Categories { get; private set; }
        public string Name { get; private set; }
        public string LicenseInfo { get; private set; }
        public IEnumerable<string> Languages { get; private set; }
        public string Url { get; private set; }
        public string LastModified { get; private set; }
        public string Documentation { get; private set; }
        public string Modified { get; private set; }
        public string SpatialReference { get; private set; }
        public string Item { get; private set; }
        public int NumViews { get; private set; }
        public string AccessInformation { get; private set; }
    }
}