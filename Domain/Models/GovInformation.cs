using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class GovInformation : BaseEntity
    {
        public Root Root { get; private set; }

        public string SearchTerm { get; private set; }

        public DateTime DateCapture { get; private set; } = DateTime.Now.ToUniversalTime();

        public IEnumerable<DownloadUrlDocument> CompleteDownloadPaths { get; private set; }

        public GovInformation(Root root, string searchTerm, IEnumerable<DownloadUrlDocument> completeDownloadPaths)
        {
            Root = root;
            SearchTerm = searchTerm;
            CompleteDownloadPaths = completeDownloadPaths;
        }
    }
}