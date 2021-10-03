using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ExtractGovWebDataRepository : IExtractGovWebDataRepository
    {
        public ExtractGovWebDataRepository()
        {
        }

        public Task<bool> SaveExtractGovData(List<GovInformation> informations)
        {
            throw new System.NotImplementedException();
        }
    }
}