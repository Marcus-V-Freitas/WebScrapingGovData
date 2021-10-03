using Application.Interfaces;
using Application.Query;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("")]
        public async Task<IActionResult> GetGovData([FromQuery] GetSearchQueryString queryString)
        {
            return Ok(await _extractGovWebDataService.GetGovData(queryString.SearchTerm));
        }
    }
}