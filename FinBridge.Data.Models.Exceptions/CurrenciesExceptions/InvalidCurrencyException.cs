namespace FinBridge.Data.Models.Exceptions.CurrenciesExceptions
{
    /// <summary>
    /// Exception thrown when an invalid or non-existent currency code is provided.
    /// </summary>
    public class InvalidCurrencyException : FinBridgeException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyException"/> class.
        /// </summary>
        /// <param name="currencyCode">The invalid currency code.</param>
        public InvalidCurrencyException(string currencyCode)
            : base($"The currency code '{currencyCode}' is either incorrect or does not exist!") { }
    }

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
