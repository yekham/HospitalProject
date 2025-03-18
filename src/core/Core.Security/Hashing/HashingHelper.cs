using System.Security.Cryptography;
using System.Text;

namespace Core.Security.Hashing;

public static class HashingHelper
{
    //HMACSHA512
    public static (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
    {
        using var hmac = new HMACSHA512();
        byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] salt = hmac.Key;

        return (hash, salt);
    }
    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}
