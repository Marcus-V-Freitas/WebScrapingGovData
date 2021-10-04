namespace Application.DTOs
{
    public class DistributionDTO : BaseEntityDTO
    {
        public string Type { get; private set; }

        public string DownloadURL { get; private set; }
        public string MediaType { get; private set; }
    }
}