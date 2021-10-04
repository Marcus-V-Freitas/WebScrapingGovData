using Application.Body;
using Application.DTOs;
using Application.Interfaces;
using Application.Query;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScrapingGovData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ExtractGovController : ControllerBase
    {
        private readonly IExtractGovWebDataService _extractGovWebDataService;

        public ExtractGovController(IExtractGovWebDataService extractGovWebDataService)
        {
            _extractGovWebDataService = extractGovWebDataService;
        }

        /// <summary>
        /// Extract all documents and data base in term
        /// </summary>
        /// <param name="searchBody"> object represent term search </param>
        /// <returns> List gov informations saved </returns>
        [HttpPost("ExtractGovData")]
        public async Task<IActionResult> ExtractGovData([FromBody] PostSearchBody searchBody)
        {
            List<GovInformationDTO> govInformationDTOs = new();

            if (await _extractGovWebDataService.ExtractGovFilesAndData(searchBody.SearchTerm))
                govInformationDTOs = await _extractGovWebDataService.GetExtractGovDataBySearchTerm(searchBody.SearchTerm);

            return Ok(govInformationDTOs);
        }

        /// <summary>
        /// Get Data based in term
        /// </summary>
        /// <param name="queryString"> object represent term search </param>
        /// <returns> List gov informations saved </returns>
        [HttpGet("GetGovData")]
        public async Task<IActionResult> GetGovData([FromQuery] GetSearchQueryString queryString)
        {
            List<GovInformationDTO> govInformationDTOs = await _extractGovWebDataService.GetExtractGovDataBySearchTerm(queryString.SearchTerm);

            if (!govInformationDTOs.Any())
                return NotFound("No information search");

            return Ok(govInformationDTOs);
        }
    }
}