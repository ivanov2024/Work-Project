namespace FinBridge.Data.Models.Exceptions.CountryCodeErrorHandler
{
    /// <summary>
    /// Exception thrown when an invalid country code is provided.
    /// </summary>
    /// <remarks>
    /// Country codes should follow the standard two-letter or three-letter format.
    /// </remarks>

    public class InvalidCountryCodeException : FinBridgeException
    {
        public InvalidCountryCodeException(string parameterName) 
            : base($"The country code '{parameterName}' is either incorrect or does not exist!") { }
    }
}
