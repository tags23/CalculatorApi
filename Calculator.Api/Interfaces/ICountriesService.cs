using Calculator.Api.Models;

namespace Calculator.Api.Interfaces
{
    public interface ICountriesService
    {
        public Task<List<CountryModel>> GetCountriesAsync();
        public Task<List<string>> GetSortedCountryNamesAsync();
    }
}
