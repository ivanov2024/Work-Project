namespace FinBridge.Data.Models.Exceptions.CountryCodeExceptions
{
    /// <summary>
    /// Exception thrown when an invalid country name is provided.
    /// </summary>
    /// <remarks>
    /// This exception is triggered when a country name does not match any recognized country in the system.
    /// </remarks>

    public class InvalidCountryNameException : FinBridgeException
    {
        public InvalidCountryNameException(string parameterName)
            :base($"The country '{parameterName}' is either incorrect or does not exist!") { }
    }
}
