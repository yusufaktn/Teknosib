using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        byte[] hash, salt;
        CreatePasswordHash("adminysf1626mya", out hash, out salt);

        string hexSalt = "0x" + BitConverter.ToString(salt).Replace("-", "");
        string hexHash = "0x" + BitConverter.ToString(hash).Replace("-", "");

        Console.WriteLine("Salt (Hex): " + hexSalt);
        Console.WriteLine("Hash (Hex): " + hexHash);
    }

    private static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new HMACSHA512();
        salt = hmac.Key; // 64-byte rastgele salt
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // 64-byte hash
    }
}