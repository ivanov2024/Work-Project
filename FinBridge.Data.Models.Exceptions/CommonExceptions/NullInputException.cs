namespace FinBridge.Data.Models.Exceptions.CommonExceptions
{
    /// <summary>
    /// Exception thrown when an input parameter is null or empty.
    /// </summary>
    /// <remarks>
    /// This exception should be used for validating user inputs to ensure required fields are not left blank.
    /// </remarks>

    public class NullInputException : FinBridgeException
    {
        public NullInputException(string parameterName)
            :base($"The input for '{parameterName}' cannot be empty or null!") { }
    }
}
