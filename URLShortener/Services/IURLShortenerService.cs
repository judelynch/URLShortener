namespace URLShortener.Services
{
    public interface IURLShortenerService
    {
        public string GetUrl(string url);

        public string PostUrl(string url);
    }
}
