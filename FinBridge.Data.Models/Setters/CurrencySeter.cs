using FinBridge.Data.Models.Enums.BankAccountEnums;

namespace FinBridge.Data.Models.Setters
{
    public static class CurrencySeter
    {
        public static string SetCurrency(string? currency, CountryCode countryCode)
            => (string.IsNullOrWhiteSpace(currency))
            ? countryCode.ToString() : currency;
    }
}
