namespace FinBridge.Data.Models
{
    internal static sealed class IBANGenerator
    {
        private static string GenerateIBAN(string accountId)
        {
            string countryCode = "BG";

            string controlDigits = "80";

            string bankCode = "BNBG";

            string accountNumber = accountId.Substring(0, 16);

            return $"{countryCode}{controlDigits}{bankCode}{accountNumber}";
        }
    }
}
