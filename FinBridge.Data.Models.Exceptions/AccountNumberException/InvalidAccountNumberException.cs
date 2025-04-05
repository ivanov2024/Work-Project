namespace FinBridge.Data.Models.Exceptions.AccountNumberException
{
    public class InvalidAccountNumberException : FinBridgeException
    {
        public InvalidAccountNumberException(string accountNumber)
            : base($"The provided account number '{accountNumber}' is either incorrect or does not exist!") { }
    }
}
