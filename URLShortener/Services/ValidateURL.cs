using System.Text.RegularExpressions;

namespace URLShortener.Services
{
    public class ValidateURL
    {
        public bool IsValid(string Url)
        {
            Regex ValidateURLRegex = new Regex("^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");
            return ValidateURLRegex.IsMatch(Url);
        }
    }
}
