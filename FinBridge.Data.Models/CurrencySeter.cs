namespace FinBridge.Data.Models
{
    public static class CurrencySeter
    {
        public static string SetCurrency(string? currency, string countryCode)
            => !string.IsNullOrWhiteSpace(currency) ? currency : countryCode;
    }
}
