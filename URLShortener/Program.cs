using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Repositories;
using URLShortener.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
builder.Services.AddRazorPages();




builder.Services.AddDbContext<URLShortenerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IURLShortenerRepo, URLShortenerRepo>();
builder.Services.AddScoped<IURLShortenerService, URLShortenerService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<URLShortenerContext>();
    dataContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();
