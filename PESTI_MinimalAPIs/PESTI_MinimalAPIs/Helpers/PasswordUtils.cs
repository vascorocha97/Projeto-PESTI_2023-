using System.Security.Cryptography;

namespace PESTI_MinimalAPIs.Helpers;

public static class PasswordUtils
{
    public static byte[] GeneratePasswordSalt()
    {
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }
    
    public static byte[] GeneratePasswordHash(string password, byte[] salt)
    {
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password), "Password cannot be null.");
        }
    
        const int numBytesRequested = 32;
        const int iterationCount = 10000;
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterationCount, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(numBytesRequested);
        }
    }
    
    public static bool ValidatePassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        var computedHash = GeneratePasswordHash(password, passwordSalt);
        return computedHash.SequenceEqual(passwordHash);
    }

}