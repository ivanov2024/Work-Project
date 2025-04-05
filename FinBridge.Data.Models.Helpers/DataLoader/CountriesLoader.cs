using Newtonsoft.Json;

namespace FinBridge.Data.Models.Helpers.DataLoader
{
    /// <summary>
    /// Static class responsible for loading country data from a JSON file.
    /// </summary>
    /// <remarks>
    /// Reads country data from a JSON file located in the application directory
    /// and maps country codes to their respective country names.
    /// </remarks>
    public static class CountriesLoader
    {
        /// <summary>
        /// The file path to the JSON file containing country data.
        /// </summary>
        private static readonly string _countriesFilePath
            = Path.Combine(Directory.GetCurrentDirectory(), "countries.json");

        /// <summary>
        /// Loads country data from the JSON file and returns a dictionary 
        /// mapping country codes to country names.
        /// </summary>
        /// <returns>
        /// A dictionary where the key is the country code (e.g., "BU") 
        /// and the value is the full country name (e.g., "Bulgaria").
        /// </returns>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the JSON file is missing.
        /// </exception>
        /// <exception cref="JsonException">
        /// Thrown if there is an error parsing the JSON data.
        /// </exception>
        public static Dictionary<string, string> LoadCountries()
        {
            var jsonData = File.ReadAllText(_countriesFilePath);

            dynamic countries = JsonConvert.DeserializeObject<dynamic>(jsonData);

            var countriesDict = new Dictionary<string, string>();

            foreach (var country in countries)
            {
                countriesDict[country.Code.ToString()] = country.Name.ToString();
            }

            return countriesDict;
        }
    }

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
