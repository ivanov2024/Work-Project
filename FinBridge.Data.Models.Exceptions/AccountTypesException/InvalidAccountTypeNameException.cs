namespace FinBridge.Data.Models.Exceptions.AccountTypesException
{
    public class InvalidTransactionTypesException : FinBridgeException
    {
        public InvalidTransactionTypesException(string accountTypeName)
            : base($"The provided account type name '{accountTypeName}' is either incorrect or does not exist!")
        {

        }
    }
}
