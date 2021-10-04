using Newtonsoft.Json;

namespace Application.DTOs
{
    public class ContactPointDTO : BaseEntityDTO
    {
        public string Type { get; private set; }

        public string Fn { get; private set; }
        public string HasEmail { get; private set; }
    }
}