namespace FinBridge.Data.Models.Exceptions
{
    /// <summary>
    /// Base exception class for all custom exceptions in FinBridge.
    /// </summary>
    /// <remarks>
    /// This class provides a standardized error message format for all derived exceptions.
    /// </remarks>
    public abstract class FinBridgeException : Exception
    {
        protected FinBridgeException(string message)
            :base($"[ERROR]: {message}") { }
    }

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
