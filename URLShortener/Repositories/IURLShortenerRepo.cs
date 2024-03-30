using URLShortener.Models;

namespace URLShortener.Repositories
{
    public interface IURLShortenerRepo
    {
        URLStringIdViewModel GetUrl(string smallUrlId);
        bool SaveUrl(URLStringIdViewModel entity);
    }
}
