using System.Security.Cryptography;

namespace ViraRankCleanApi.Helpers
{
    public static class PasswordHelper
    {
        private const int Iterations = 100_000;
        private const int KeySize = 64; 
        private const int SaltSize = 32; 
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

        public static void CreatePasswordHash(string password, out byte[] salt, out byte[] hash)
        {
            salt = RandomNumberGenerator.GetBytes(SaltSize);
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, Algorithm);
            hash = pbkdf2.GetBytes(KeySize);
        }

        public static bool VerifyPassword(string password, byte[] salt, byte[] expectedHash)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, Algorithm);
            var computedHash = pbkdf2.GetBytes(KeySize);
            return CryptographicOperations.FixedTimeEquals(computedHash, expectedHash);
        }
    }
}
