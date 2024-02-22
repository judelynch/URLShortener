using System.Text;

namespace URLShortener.Services
{
    public class StringGenerator
    {
        public string DecodeString(string url)
        {
            var base64EncodedBytes = Convert.FromBase64String(url);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string EncodeString(string url)
        {
            var textBytes = Encoding.UTF8.GetBytes(url);
            return Convert.ToBase64String(textBytes);
        }
    }
}
