using Newtonsoft.Json;

namespace FinBridge.Data.Models.Helpers.DataLoader
{
    public static class CountriesLoader
    {
        private static readonly string _countriesFilePath 
            = Path.Combine(Directory.GetCurrentDirectory(), "countries.json");

        public static Dictionary<string, string> LoadCountries()
        {
            var jsonData = File.ReadAllText(_countriesFilePath);

            dynamic countries = JsonConvert.DeserializeObject<dynamic>(jsonData);

            var countriesDict = new Dictionary<string, string>();

            foreach (var country in countries.countries)
            {
                countriesDict[country.code.ToString()] = country.name.ToString();
            }

            return countriesDict;
        }
    }
}
