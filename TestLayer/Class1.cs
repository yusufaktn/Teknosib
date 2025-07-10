using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        byte[] hash, salt;
        CreatePasswordHash("adminysf1626mya", out hash, out salt);
                Console.WriteLine("Salt (Base64): " + Convert.ToBase64String(salt));
        Console.WriteLine("Hash (Base64): " + Convert.ToBase64String(hash));
    }

    private static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new HMACSHA512();
        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}