using FinBridge.Data.Models.Exceptions.CommonExceptions;
using FinBridge.Data.Models.Exceptions.CurrenciesExceptions;
using FinBridge.Data.Models.Helpers.DataLoader;

namespace FinBridge.Data.Models.Helpers
{
    /// <summary>
    /// Provides validation for currency codes by checking if they exist in the loaded currency data.
    /// </summary>
    public static class CurrencyInputValidator
    {
        /// <summary>
        /// Checks if the given currency code is valid.
        /// </summary>
        /// <param name="currencyCode">The currency code to validate.</param>
        /// <returns>True if the currency code is valid; otherwise, throws an exception.</returns>
        /// <exception cref="InvalidCurrencyException">Thrown when the currency code is invalid or does not exist.</exception>
        public static bool IsValid(string currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new NullInputException("Currency code cannot be null or empty.");

            var currencies = CurrenciesLoader.LoadCurrencies();

            if (!currencies.ContainsKey(currencyCode))
                throw new InvalidCurrencyException(currencyCode);

            return true;
        }
    }

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
