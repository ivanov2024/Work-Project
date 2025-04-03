using FinBridge.Data.Models.BankAccountEnums;
using System.Numerics;
using System.Text;

namespace FinBridge.Data.Models
{
    /// <summary>
    /// This class is used to generate IBAN for the corresponding country 
    /// </summary>
    internal static class IBANGenerator
    {
        public static string GenerateIBAN(CountryCode countryCode, string bankCode, string accountNumber)
        {
            //Temporary using "00" as check digits
            string ibanWithoutControl = $"{countryCode}00{bankCode}{accountNumber}";

            // We calculate the checksum with an optimized algorithm
            int controlDigits = 98 - Modulo97(ibanWithoutControl + countryCode);

            // Return the generated IBAN
            return $"{countryCode}{controlDigits:D2}{bankCode}{accountNumber}";
        }

        private static int Modulo97(string iban)
        {
            long remainder = 0;

            foreach (char ch in iban)
            {
                int value = char.IsLetter(ch) ? ch - 'A' + 10 : ch - '0';
                remainder = (remainder * 10 + value) % 97;
            }

            return (int)remainder;
        }
    }

    // Code written by @ivanov2024
    // All rights served
}
