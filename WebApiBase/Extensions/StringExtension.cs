using System.Security.Cryptography;
using System.Text;

namespace WebApiBase.Extensions
{
    public static class StringExtension
    {
        public static string ToSha256(this string value)
        {
            using var sha256Hash = SHA256.Create();

            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            var stringBuilder = new StringBuilder();
            foreach (var item in bytes)
            {
                stringBuilder.Append(item.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}