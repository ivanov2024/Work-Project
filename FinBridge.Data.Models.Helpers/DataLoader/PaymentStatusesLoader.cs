using FinBridge.Data.Models.Exceptions.CommonExceptions;
using FinBridge.Data.Models.Helpers.DTOs.Import;
using Newtonsoft.Json;

namespace FinBridge.Data.Models.Helpers.DataLoader
{
    public static class PaymentStatusesLoader
    {
        private static readonly string _paymentStatusesFilePath
            = Path.Combine(Directory.GetCurrentDirectory(), "paymentStatuses.json");

        public static Dictionary<string, string> LoadCountries()
        {
            var jsonData 
                = File.ReadAllText(_paymentStatusesFilePath);

            ImportPaymentStatusesDto[]? countries
                = JsonConvert.DeserializeObject<ImportPaymentStatusesDto[]>(jsonData)
                ?? throw new JSONDeserializationException(Path.GetFileName(_paymentStatusesFilePath));

            var paymentStatusesDict 
                = new Dictionary<string, string>();

            foreach (var country in countries)
            {
                paymentStatusesDict[country.Status.ToString()] = country.Code.ToString();
            }

            return paymentStatusesDict;
        }
    }
}
