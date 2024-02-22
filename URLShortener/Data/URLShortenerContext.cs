using Microsoft.EntityFrameworkCore;
using URLShortener.Models;

namespace URLShortener.Data
{
    public class URLShortenerContext:DbContext
    {
        public URLShortenerContext(DbContextOptions<URLShortenerContext> options) : base(options)
        {
        }

        public DbSet<URLShortenerViewModel> Urls { get; set; }
    }
}
