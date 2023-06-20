using System.Security.Cryptography;

namespace PESTI_MinimalAPIs.Helpers;

public static class PasswordUtils
{
    public static byte[] GeneratePasswordSalt()
    {
        byte[] salt = new byte[32];
        using (var random = RandomNumberGenerator.Create())
        {
            //fills salt array with values
            random.GetBytes(salt);
        }
        return salt;
    }
    
    public static byte[] GeneratePasswordHash(string userPassword, byte[] salt)
    {
        //checks if password is null
        if (userPassword == null)
        {
            throw new ArgumentNullException(nameof(userPassword), "Password cannot be null.");
        }
        
        //length of the password hash array
        const int hashLength = 32;
        //number of iterations
        const int iterationCount = 10000;
        
        //uses PBKDF2
        using (var hashAlgorithm = new Rfc2898DeriveBytes(userPassword, salt, iterationCount, HashAlgorithmName.SHA256))
        {
            return hashAlgorithm.GetBytes(hashLength);
        }
    }
    
    public static bool ValidatePassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        var computedHash = GeneratePasswordHash(password, passwordSalt);
        return computedHash.SequenceEqual(passwordHash);
    }

}