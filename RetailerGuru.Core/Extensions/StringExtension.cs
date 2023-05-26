using System.Security.Cryptography;
using System.Text;

namespace RetailerGuru.Core.Extensions
{
    public static class StringExtension
    {
        public static string Encrypt(this string text)
        {
            using var sha = SHA256.Create();

            return Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(text)));
        }

        public static string Encode64(this string text)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(text));
        }

        public static string Decode64(this string text)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(text));
        }
    }
}
