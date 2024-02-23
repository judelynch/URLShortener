using System.Text.RegularExpressions;

namespace URLShortener.Services
{
    public class ValidateURL
    {
        public bool IsValid(string Url)
        {
           Regex ValidateURLRegex = new Regex(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$");
           
            return ValidateURLRegex.IsMatch(Url);
        }
    }
}
