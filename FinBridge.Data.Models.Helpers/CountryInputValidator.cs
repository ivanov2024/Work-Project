using FinBridge.Data.Models.Exceptions.CommonExceptions;
using FinBridge.Data.Models.Exceptions.CountryCodeErrorHandler;
using FinBridge.Data.Models.Exceptions.CountryCodeExceptions;
using FinBridge.Data.Models.Helpers.DataLoader;

namespace FinBridge.Data.Models.Helpers
{

    /// <summary>
    /// Validates user input to check whether it is a valid country name or country code.
    /// </summary>
    /// <remarks>
    /// This class determines if the input is a country name or code and validates accordingly. 
    /// Throws specific exceptions if the input is invalid.
    /// </remarks>

    public static class CountryInputValidator
    {
        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new NullInputException(input);

            if (input.Length < 3)
                return IsCountryCodeValid(input);
            else
                return IsCountryNameValid(input);
        }

        private static bool IsCountryCodeValid(string input)
        {
            var countries = CountriesLoader.LoadCountries();
            if (!countries.ContainsKey(input))
                throw new InvalidCountryCodeException(input);

            return true;
        }

        private static bool IsCountryNameValid(string input)
        {
            var countries = CountriesLoader.LoadCountries();
            if (!countries.ContainsValue(input))
                throw new InvalidCountryNameException(input);

            return true;
        }
    }


    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
