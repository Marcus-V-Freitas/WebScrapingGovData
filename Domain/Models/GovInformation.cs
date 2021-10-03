using System.Collections.Generic;

namespace Domain.Models
{
    public class GovInformation : BaseEntity
    {
        public Root Root { get; set; }

        public IEnumerable<DownloadUrlDocument> CompleteDownloadPaths { get; set; }
    }
}