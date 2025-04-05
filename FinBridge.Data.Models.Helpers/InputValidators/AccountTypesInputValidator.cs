using FinBridge.Data.Models.Exceptions.AccountTypesException;
using FinBridge.Data.Models.Exceptions.CommonExceptions;
using FinBridge.Data.Models.Helpers.DataLoader;

namespace FinBridge.Data.Models.Helpers.InputValidators
{
    /// <summary>
    /// Validates user input to check whether it is a valid account type name.
    /// </summary>
    /// <remarks>
    /// This class validates if the input is a valid account type name and throws an exception 
    /// if the name is invalid.
    /// </remarks>

    public static class AccountTypesInputValidator
    {
        /// <summary>
        /// Validates the input to check if it is a valid account type name.
        /// </summary>
        /// <param name="input">The user input to be validated (account type name).</param>
        /// <returns>True if valid, otherwise throws an exception.</returns>
        public static bool IsAccountTypeValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new NullInputException(input);

            return IsAccountTypeNameValid(input);
        }

        /// <summary>
        /// Validates if the input is a valid account type name.
        /// </summary>
        /// <param name="input">The account type name to validate.</param>
        /// <returns>True if the name is valid, otherwise throws an exception.</returns>
        private static bool IsAccountTypeNameValid(string input)
        {
            var accountTypes = AccountTypesLoader.LoadAccountTypes();
            if (!accountTypes.ContainsValue(input))
                throw new InvalidTransactionTypesException(input);

            return true;
        }
    }

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
