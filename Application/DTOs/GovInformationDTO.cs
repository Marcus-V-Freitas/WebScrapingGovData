using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class GovInformationDTO : BaseEntityDTO
    {
        public RootDTO Root { get; private set; }

        public string SearchTerm { get; private set; }

        public DateTime DateCapture { get; private set; } = DateTime.Now.ToUniversalTime();

        public IEnumerable<DownloadUrlDocumentDTO> CompleteDownloadPaths { get; private set; }
    }
}