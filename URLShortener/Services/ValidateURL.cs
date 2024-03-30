using System.Text.RegularExpressions;

namespace URLShortener.Services
{
    public class ValidateURL
    {
        public bool IsValid(string Url)
        {
            if (string.IsNullOrEmpty(Url))
            {
                return false;
            }

            //Regex ValidateURLRegex = new Regex(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$");
            Regex ValidateURLRegex = new Regex(@"^(?:https?://)(?:[\w-]+\.)+(?:[a-z]{2,}|(?:xn--)?[a-z0-9]+)(?::\d+)?(?:\/[\w-]*)*(?:\?(?:[\w-]+=[\w-]*&?)*)(?:#[\w-]*)?$");
            return ValidateURLRegex.IsMatch(Url);
        }
    }
}
