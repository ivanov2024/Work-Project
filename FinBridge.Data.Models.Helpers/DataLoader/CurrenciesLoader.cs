using FinBridge.Data.Models.Exceptions.CommonExceptions;
using FinBridge.Data.Models.Helpers.DTOs.Import;
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
            ImportCurrenciesDto[]? currencyData
                = JsonConvert.DeserializeObject<ImportCurrenciesDto[]>(jsonData);

            if (currencyData == null)
                throw new JSONDeserializationException(Path.GetFileName(_currenciesFilePath));

            var currenciesDict = new Dictionary<string, string>();

            foreach (var entry in currencyData)
            {
                currenciesDict[entry.Code] = entry.Currency;
            }

            return currenciesDict;
        }
    }
}
