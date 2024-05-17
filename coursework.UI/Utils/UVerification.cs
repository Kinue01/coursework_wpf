using System.Security.Cryptography;
using System.Text;

namespace coursework.UI.Utils
{
    public class UVerification
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
    }
}
