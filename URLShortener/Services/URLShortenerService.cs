using URLShortener.Models;
using URLShortener.Repositories;

namespace URLShortener.Services
{
    public class URLShortenerService : IURLShortenerService
    {
        private readonly IURLShortenerRepo _uRLShortenerRepo;

        public URLShortenerService(IURLShortenerRepo uRLShortenerRepo)
        {
            _uRLShortenerRepo = uRLShortenerRepo;
        }

        public string GetUrl(Guid UrlId)
        {
            // use fluent validation 

            StringGenerator sGenerator = new StringGenerator();

            try
            {
                //Get Url From Database
                URLShortenerViewModel CodedUrl = _uRLShortenerRepo.GetUrl(UrlId);
                //Decode and Return Long Url
                return sGenerator.DecodeString(CodedUrl.Url);
            }
            catch 
            {
               throw;
            }
        }

        public string PostUrl(string url)
        {
            ValidateURL valUrl = new ValidateURL();

            if (valUrl.IsValid(url))
            {

                StringGenerator sGenerator = new StringGenerator();
                string encodedUrl = "";
                Guid UrlId = Guid.Empty;

                try
                {
                    // encode url 
                    encodedUrl = sGenerator.EncodeString(url);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                try
                {
                    //Generat Id 
                    UrlId = GuidGenerator.Create(encodedUrl);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                try
                {
                    // Check if it already exists. 
                    URLShortenerViewModel currentUrl = _uRLShortenerRepo.GetUrl(UrlId);
                    if (currentUrl == null)
                    {
                        //Add if not exists 
                        _uRLShortenerRepo.SaveSmallUrl(new URLShortenerViewModel(UrlId, encodedUrl));
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                // return "small" Url
                return "https://localhost:7056/Url?url=" + UrlId.ToString();
            }
            else 
            {
                return "URL is Invalid";
            }
        }
    }
}
