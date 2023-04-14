using Calculator.Api.Entities.Responses;
using Calculator.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Api.Controllers
{
    [Route("api/v1/countries")]
    [Produces("application/json")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService ?? throw new ArgumentNullException(nameof(countriesService));
        }

        [HttpGet]
        [Route("GetAlphabeticallySortedCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SortedCountriesResponse>> Get()
        {
            var sortedCountryNames = await _countriesService.GetSortedCountryNamesAsync();

            var response = new SortedCountriesResponse()
            {
                Countries = sortedCountryNames
            };

            return Ok(response);
        }
    }
}
