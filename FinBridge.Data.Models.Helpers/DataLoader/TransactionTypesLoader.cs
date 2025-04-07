using FinBridge.Data.Models.Exceptions.CommonExceptions;
using FinBridge.Data.Models.Helpers.DTOs.Import;
using Newtonsoft.Json;

namespace FinBridge.Data.Models.Helpers.DataLoader
{
    public static class TransactionTypesLoader
    {
        private static readonly string _transactionTypesFilePath
           = Path.Combine(Directory.GetCurrentDirectory(), "transactionTypes.json");

        public static Dictionary<string, string> LoadTransactionTypes()
        {
            var jsonData = File.ReadAllText(_transactionTypesFilePath);
            ImportTransactionTypesDto[]? transactionTypesData 
                = JsonConvert.DeserializeObject<ImportTransactionTypesDto[]>(jsonData)
                ?? throw new JSONDeserializationException(Path.GetFileName(_transactionTypesFilePath));

            var transactionTypesDict = new Dictionary<string, string>();

            foreach (var entry in transactionTypesData)
            {
                transactionTypesDict[entry.TransactionType.ToString()] = entry.Description.ToString();
            }

            return transactionTypesDict;
        }
    }
}
