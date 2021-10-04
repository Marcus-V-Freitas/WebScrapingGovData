using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExtractGovWebDataService
    {
        Task<bool> ExtractGovFilesAndData(string searchTerm);

        Task<List<GovInformationDTO>> GetExtractGovDataBySearchTerm(string searchTerm);
    }
}