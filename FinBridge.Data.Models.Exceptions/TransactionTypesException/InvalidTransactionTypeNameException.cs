namespace FinBridge.Data.Models.Exceptions.TransactionTypesException
{
    public class InvalidTransactionTypeNameException : FinBridgeException
    {
        public InvalidTransactionTypeNameException(string transactionTypeName)
            : base($"The provided transaction type name '{transactionTypeName}' is either incorrect or does not exist!") { }
    }
}
