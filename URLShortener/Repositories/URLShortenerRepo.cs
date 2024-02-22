using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Models;

namespace URLShortener.Repositories
{
    public class URLShortenerRepo : IURLShortenerRepo
    {
        private readonly URLShortenerContext _context;
        public URLShortenerRepo(URLShortenerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public URLShortenerViewModel GetUrl(Guid smallUrlId)
        {
            return _context.Urls.Where(c => c.Id == smallUrlId).FirstOrDefault();
        }

        public bool SaveSmallUrl(URLShortenerViewModel entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Urls.Add(entity);
                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }

        }
    }
}

