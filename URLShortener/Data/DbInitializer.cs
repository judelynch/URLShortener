namespace URLShortener.Data
{
    public class DbInitializer
    {
        public static void Initialize(URLShortenerContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
