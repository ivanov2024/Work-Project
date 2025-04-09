using FinBridge.Data.Models.Exceptions.CommonExceptions;
using FinBridge.Data.Models.Helpers.DTOs.Import;
using Newtonsoft.Json;

namespace FinBridge.Data.Models.Helpers.DataLoader
{
    public static class CreditTypesLoader
    {
        private static readonly string _creditTypesFilePath
            = Path.Combine(Directory.GetCurrentDirectory(), "creditTypes.json");

        public static Dictionary<string, string> LoadCreditTypesTypes()
        {
            var jsonData = File.ReadAllText(_creditTypesFilePath);

            ImportCreditTypesDto[]? accountTypes
                = JsonConvert.DeserializeObject<ImportCreditTypesDto[]>(jsonData)
                ?? throw new JSONDeserializationException(Path.GetFileName(_creditTypesFilePath));

            var accountTypesDict = new Dictionary<string, string>();

            foreach (var accountType in accountTypes)
            {
                accountTypesDict[accountType.CreditType.ToString()] = accountType.Code.ToString();
            }

            return accountTypesDict;
        }
    }
}
