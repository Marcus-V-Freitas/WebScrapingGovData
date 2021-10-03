using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExtractGovWebDataService
    {
        Task<bool> GetGovData(string searchTerm);
    }
}