using System.Security.Cryptography;

using System.Text;

namespace FinBridge.Data.Models.Setters
{

    /// <summary>
    /// This class handles the process of setting and validating passwords with salting and hashing.
    /// </summary>
    /// <remarks>
    /// The password and salt are stored separately in the database, concatenated with a dot for easy separation.
    /// </remarks>
    public static class PasswordSetter
    {
        private static readonly int SaltLength = 32; // Defines the length of the salt in bytes

        /// <summary>
        /// Sets the password by adding a salt and hashing the result.
        /// </summary>
        /// <param name="password">The raw password entered by the user.</param>
        /// <returns>A string containing the hashed password and salt, separated by a dot.</returns>
        public static string SetPassword(string password)
        {
            var salt = GenerateSalt();
            string passwordWithSalt = password + salt;

            byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);
            byte[] hashedBytes = SHA256.HashData(bytes);

            string hashedPassword = Convert.ToBase64String(hashedBytes);

            // Return the concatenated hashed password and salt, separated by a dot
            return $"{hashedPassword}.{salt}";
        }

        /// <summary>
        /// Generates a random salt using a secure random number generator.
        /// </summary>
        /// <returns>A base64 encoded string representing the salt.</returns>
        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[SaltLength];
            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }
    }

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}