using URLShortener.Data;
using URLShortener.Models;

namespace URLShortener.Repositories
{
    public class URLShortenerRepo : IURLShortenerRepo
    {
        private readonly URLShortenerContext _context;
        private readonly ILogger<URLShortenerRepo> _logger;

        public URLShortenerRepo(URLShortenerContext context, ILogger<URLShortenerRepo> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public URLStringIdViewModel GetUrl(string SmallUrlId)
        {
            try
            {
                return _context.UrlStrings.Where(c => c.Id == SmallUrlId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool SaveUrl(URLStringIdViewModel Entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.UrlStrings.Add(Entity);
                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }
    }
}

