using System.Security.Cryptography;
using System.Text;

namespace BookStore.Entities.Helpers
{
    public class Md5Helper
    {
        public static string CreateMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
