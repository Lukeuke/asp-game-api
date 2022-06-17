using System.Security.Cryptography;
using Application.Models;

namespace Application.Services;

public static class AuthenticationHelper
{
    private static RandomNumberGenerator rng = RandomNumberGenerator.Create();
    
    private static byte[] GenerateSalt(int size)
    {
        var salt = new byte[size];
        rng.GetBytes(salt);
        return salt;
    }

    public static string GenerateHash(string password, string salt)
    {
        var salt1 = Convert.FromBase64String(salt);

        using var hashGenerator = new Rfc2898DeriveBytes(password, salt1);
        hashGenerator.IterationCount = 10101;
        var bytes = hashGenerator.GetBytes(24);
        return Convert.ToBase64String(bytes);
    }

    public static void ProvideSaltAndHash(this Player player)
    {
        var salt = GenerateSalt(24);
        player.Salt = Convert.ToBase64String(salt);
        player.Password = GenerateHash(player.Password, player.Salt);
    }
}