using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<GovInformation>> GetExtractGovDataBySearchTerm(string searchTerm)
        {
            return await _govContext.GovInformations
                                    .AsQueryable()
                                    .Where(x => x.SearchTerm.Contains(searchTerm))
                                    .ToListAsync();
        }

        public async Task<bool> SaveExtractGovData(List<GovInformation> informations)
        {
            _govContext.GovInformations.AddRange(informations);
            return await Commit();
        }
    }
}