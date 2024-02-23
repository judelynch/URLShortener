using System.Text;

namespace URLShortener.Services
{
    public class StringConvert
    {
        public string DecodeString(string url)
        {
            var Base64EncodedBytes = Convert.FromBase64String(url);
            return Encoding.UTF8.GetString(Base64EncodedBytes);
        }

        public string EncodeString(string url)
        {
            var TextBytes = Encoding.UTF8.GetBytes(url);
            return Convert.ToBase64String(TextBytes);
        }
    }
}
