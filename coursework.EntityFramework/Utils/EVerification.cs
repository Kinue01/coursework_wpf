using System.Security.Cryptography;
using System.Text;

namespace coursework.EntityFramework.Utils
{
    public class EVerification
    {
        public string GetSHA512Hash(string input)
        {
            byte[] data = SHA512.HashData(Encoding.Default.GetBytes(input));

            StringBuilder sb = new();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public bool VerifySHA512Hash(string input, string hash)
        {
            string hashOfInput = GetSHA512Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (comparer.Compare(hashOfInput, hash) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
