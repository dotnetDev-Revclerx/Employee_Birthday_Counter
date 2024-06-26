using System;
using System.Linq;

namespace AutoLogin
{
    internal partial class Program
    {
        private static string GenerateRandomEmail()
        {
            Random random = new Random();
            string email = $"aniket{random.Next(1, 1000)}@gmail.com";
            return email;
        }

        private static string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string password = new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }
    }
}
