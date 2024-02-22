namespace URLShortener.Services
{
    public interface IURLShortenerService
    {
        public string GetUrl(Guid url);

        public string PostUrl(string url);
    }
}
