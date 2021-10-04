using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExtractGovWebDataRepository : IUnitOfWork
    {
        Task<bool> SaveExtractGovData(List<GovInformation> informations);

        Task<List<GovInformation>> GetExtractGovDataBySearchTerm(string searchTerm);
    }
}