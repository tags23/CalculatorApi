using Calculator.Api.Interfaces;
using Calculator.Api.Models;
using RestSharp;
using System.Text.Json;

namespace Calculator.Api.Services
{
    public class CountriesService : ICountriesService
    {
        private const string Endpoint = "https://restcountries.com/v3.1/all";

        private static RestClient _client;
        private RestRequest _request;

        public CountriesService()
        {
            _client = new RestClient(Endpoint);
            _request = new RestRequest();
        }

        public async Task<List<CountryModel>> GetCountriesAsync()
        {
            var response = await _client.GetAsync(_request);
            var deserializedCountries = JsonSerializer.Deserialize<List<CountryModel>>(response.Content);

            return deserializedCountries;
        }

        public async Task<List<string>> GetSortedCountryNamesAsync()
        {
            var countryNames = new List<string>();

            var countries = await GetCountriesAsync();
            countries.ForEach(x => countryNames.Add(x.CountryName.Official));
            countryNames.Sort();

            return countryNames;
        }
    }
}
