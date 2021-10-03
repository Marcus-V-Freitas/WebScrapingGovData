using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ExtractGovWebDataRepository : IExtractGovWebDataRepository
    {
        private readonly ExtractGovContext _govContext;

        public ExtractGovWebDataRepository(ExtractGovContext govContext)
        {
            _govContext = govContext;
        }

        public async Task<bool> Commit()
        {
            return await _govContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveExtractGovData(List<GovInformation> informations)
        {
            _govContext.GovInformations.AddRange(informations);
            return await Commit();
        }
    }
}