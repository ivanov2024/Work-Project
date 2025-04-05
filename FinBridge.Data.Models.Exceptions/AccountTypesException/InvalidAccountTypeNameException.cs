namespace FinBridge.Data.Models.Exceptions.AccountTypesException
{
    public class InvalidAccountTypeNameException : FinBridgeException
    {
        public InvalidAccountTypeNameException(string accountTypeName)
            : base($"The provided account type name '{accountTypeName}' is either incorrect or does not exist!")
        {

        }
    }
}
