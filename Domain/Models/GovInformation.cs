using System.Collections.Generic;

namespace Domain.Models
{
    public class GovInformation
    {
        public Root Root { get; set; }

        public List<string> CompleteDownloadPaths { get; set; }
    }
}