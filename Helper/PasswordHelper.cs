using System.Security.Cryptography;

namespace ViraRankApi.Helpers
{
    public static class PasswordHelper
    {
        private const int Iterations = 100_000;

        public static void CreatePasswordHash(string password, out byte[] salt, out byte[] hash)
        {
            salt = RandomNumberGenerator.GetBytes(32);
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);
            hash = pbkdf2.GetBytes(64);
        }

        public static bool VerifyPassword(string password, byte[] salt, byte[] expectedHash)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);
            var computed = pbkdf2.GetBytes(64);
            return CryptographicOperations.FixedTimeEquals(computed, expectedHash);
        }
    }
}
