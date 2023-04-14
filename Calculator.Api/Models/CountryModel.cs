using System.Text.Json.Serialization;

namespace Calculator.Api.Models
{
    public class CountryModel
    {
        [JsonPropertyName("name")]
        public Name CountryName { get; set; }
        public class Name
        {
            [JsonPropertyName("official")]
            public string Official { get; set; }
        }
    }
}
