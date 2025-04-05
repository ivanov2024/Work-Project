using FinBridge.Data.Models.Exceptions.AccountNumberException;
using FinBridge.Data.Models.Exceptions.CommonExceptions;
using System.Text;

namespace FinBridge.Data.Models.Generators
{
    /// <summary>
    /// Provides functionality for generating and validating account numbers
    /// using the Damm checksum algorithm.
    /// </summary>
    /// <remarks>
    /// The generated account number is 16 digits long and ends with a checksum digit.
    /// The first few digits can simulate a real bank code for more realism.
    /// </remarks>
    public static class AccountNumberGenerator
    {
        private static readonly int[,] dammTable = new int[,]
        {
            {0,3,1,7,5,9,8,6,4,2},
            {7,0,9,2,1,5,4,8,6,3},
            {4,2,0,6,8,7,1,3,5,9},
            {1,7,5,0,9,8,3,4,2,6},
            {6,1,2,3,0,4,5,9,7,8},
            {3,6,7,4,2,0,9,5,8,1},
            {5,8,6,9,7,2,0,1,3,4},
            {8,9,4,5,3,6,2,0,1,7},
            {9,4,3,8,6,1,7,2,0,5},
            {2,5,8,1,4,3,6,7,9,0}
        };

        /// <summary>
        /// Generates a realistic 16-digit bank account number using the Damm checksum algorithm.
        /// </summary>
        /// <returns>A valid 16-digit account number as a string.</returns>
        public static string GenerateAccountNumber()
        {
            var random = new Random();
            var sb = new StringBuilder();

            // Add a fixed prefix to simulate a real bank code (e.g., 5000)
            sb.Append("5000");

            // Generate 11 random digits after the prefix
            for (int i = 0; i < 11; i++)
            {
                sb.Append(random.Next(0, 10));
            }

            // Calculate the checksum digit using Damm algorithm
            string partial = sb.ToString();
            int checksum = CalculateDammChecksum(partial);
            sb.Append(checksum);

            return sb.ToString();
        }

        /// <summary>
        /// Validates a given account number using the Damm checksum algorithm.
        /// </summary>
        /// <param name="accountNumber">The account number to validate.</param>
        /// <returns>Returns true if the account number is valid, otherwise false.</returns>
        /// <exception cref="NullInputException">Thrown when the input account number is null or empty.</exception>
        /// <remarks>
        /// This method ensures that the account number is composed of digits only
        /// and is exactly 16 characters long. The Damm checksum algorithm is applied
        /// to validate the number.
        /// </remarks>
        public static bool IsValid(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber) || accountNumber.Length != 16)
                throw new NullInputException(accountNumber);

            int interim = 0;
            foreach (char digit in accountNumber)
            {
                if (!char.IsDigit(digit))
                    return false;

                interim = dammTable[interim, digit - '0'];
            }

            if (interim != 0)
            {
                throw new InvalidAccountNumberException(accountNumber);
            }

            return true;
        }

        /// <summary>
        /// Calculates the Damm checksum digit for the given numeric string.
        /// </summary>
        /// <param name="number">The number to calculate the checksum for.</param>
        /// <returns>The checksum digit.</returns>
        private static int CalculateDammChecksum(string number)
        {
            int interim = 0;

            foreach (char digit in number)
            {
                interim = dammTable[interim, digit - '0'];
            }

            return interim;
        }
    }

    /// <author>ivanov2024</author>
    /// <copyright>Copyright © 2025 FinBridge</copyright>
}
