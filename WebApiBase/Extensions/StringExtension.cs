using System.Security.Cryptography;
using System.Text;

namespace WebApiBase.Extensions
{
    public static class StringExtension
    {
        public static string ToSha256(this string value)
        {
            var bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value));

            var stringBuilder = new StringBuilder();
            foreach (var item in bytes)
            {
                stringBuilder.Append(item.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}