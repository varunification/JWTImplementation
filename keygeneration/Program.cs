using System;
using System.Security.Cryptography;

namespace key {
    public class KeyGenerator
    {
        public static string GenerateKey(int size = 32)
        {
            var key = new byte[size];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(key);
            }
            return Convert.ToBase64String(key);
        }


        public static void Main()
        {
            // Example usage:
            var key = KeyGenerator.GenerateKey();
            Console.WriteLine(key); // This is your secure key
        }
    }
}