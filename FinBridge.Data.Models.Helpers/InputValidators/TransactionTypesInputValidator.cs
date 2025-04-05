using FinBridge.Data.Models.Exceptions.CommonExceptions;
using FinBridge.Data.Models.Exceptions.TransactionTypesException;
using FinBridge.Data.Models.Helpers.DataLoader;

namespace FinBridge.Data.Models.Helpers.InputValidators
{
    class TransactionTypesInputValidator
    {
        public static bool IsTransactionTypeValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new NullInputException(input);

            return IsTransactionTypeNameValid(input);
        }

        private static bool IsTransactionTypeNameValid(string input)
        {
            var transactionTypes = TransactionTypesLoader.LoadTransactionTypes();
            if (!transactionTypes.ContainsKey(input))
                throw new InvalidTransactionTypeNameException(input);

            return true;
        }
    }
}
