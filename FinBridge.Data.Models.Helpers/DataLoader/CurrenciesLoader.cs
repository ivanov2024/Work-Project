using Newtonsoft.Json;

namespace FinBridge.Data.Models.Helpers.DataLoader
{
    public static class CurrenciesLoader
    {
        private static readonly string _currenciesFilePath
            = Path.Combine(Directory.GetCurrentDirectory(), "currencies.json");

        public static Dictionary<string, string> LoadCurrencies()
        {
            var jsonData = File.ReadAllText(_currenciesFilePath);
            dynamic currencyData = JsonConvert.DeserializeObject<dynamic>(jsonData);

            var currenciesDict = new Dictionary<string, string>();

            foreach (var entry in currencyData)
            {
                currenciesDict[entry.Code.ToString()] = entry.Currency.ToString();
            }

            return currenciesDict;
        }
    }
}
