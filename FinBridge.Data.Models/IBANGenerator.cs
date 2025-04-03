using FinBridge.Data.Models.BankAccountEnums;

namespace FinBridge.Data.Models
{
    /// <summary>
    /// Provides functionality for generating IBANs based on country codes.
    /// </summary>
    /// <remarks>
    /// This class generates IBAN numbers by following country-specific rules
    /// and computing the correct checksum using the MOD 97 algorithm.
    /// </remarks>
    internal static class IBANGenerator
    {
        /// <summary>
        /// Generates a valid IBAN for a given country, bank code, and account number.
        /// </summary>
        /// <param name="countryCode">The country code (ISO-like format) for the IBAN.</param>
        /// <param name="bankCode">The unique bank identifier.</param>
        /// <param name="accountNumber">The customer's account number.</param>
        /// <returns>A valid IBAN string.</returns>
        public static string GenerateIBAN(CountryCode countryCode, string bankCode, string accountNumber)
        {
            // Temporarily using "00" as control digits
            string ibanWithoutControl = $"{countryCode}00{bankCode}{accountNumber}";

            // Calculate control digits using MOD 97 algorithm
            int controlDigits = 98 - Modulo97(ibanWithoutControl + countryCode);

            // Return the properly formatted IBAN
            return $"{countryCode}{controlDigits:D2}{bankCode}{accountNumber}";
        }

        /// <summary>
        /// Computes the MOD 97 checksum for an IBAN.
        /// </summary>
        /// <param name="iban">The IBAN string to validate.</param>
        /// <returns>The remainder when dividing by 97.</returns>
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

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
