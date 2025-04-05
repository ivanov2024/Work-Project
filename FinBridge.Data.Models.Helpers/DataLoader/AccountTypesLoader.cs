using Newtonsoft.Json;

namespace FinBridge.Data.Models.Helpers.DataLoader
{
    /// <summary>
    /// Static class responsible for loading account type data from a JSON file.
    /// </summary>
    /// <remarks>
    /// Reads account type data from a JSON file located in the application directory
    /// and maps account type codes to their respective account type names.
    /// </remarks>
    public static class AccountTypesLoader
    {
        /// <summary>
        /// The file path to the JSON file containing account type data.
        /// </summary>
        private static readonly string _accountTypesFilePath
            = Path.Combine(Directory.GetCurrentDirectory(), "accountTypes.json");

        /// <summary>
        /// Loads account type data from the JSON file and returns a dictionary 
        /// mapping account type codes to account type names.
        /// </summary>
        /// <returns>
        /// A dictionary where the key is the account type code (e.g., 0) 
        /// and the value is the full account type name (e.g., "CheckingAccount").
        /// </returns>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the JSON file is missing.
        /// </exception>
        /// <exception cref="JsonException">
        /// Thrown if there is an error parsing the JSON data.
        /// </exception>
        public static Dictionary<int, string> LoadAccountTypes()
        {
            var jsonData = File.ReadAllText(_accountTypesFilePath);

            dynamic accountTypes = JsonConvert.DeserializeObject<dynamic>(jsonData);

            var accountTypesDict = new Dictionary<int, string>();

            foreach (var accountType in accountTypes)
            {
                accountTypesDict[(int)accountType.Code] = accountType.Type.ToString();
            }

            return accountTypesDict;
        }
    }

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
