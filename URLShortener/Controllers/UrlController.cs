using Microsoft.AspNetCore.Mvc;

using URLShortener.Services;


namespace URLShortener.Controllers
{
  
    [Route("[controller]")]
    public class UrlController : Controller
    {
        private readonly IURLShortenerService _smallUrlService;

        public UrlController(IURLShortenerService service)
        {
            _smallUrlService = service ?? throw new ArgumentNullException(nameof(service));

        }

        [HttpGet]
        public RedirectResult Get(Guid url)
        {
            //Get Url and Redirect to it
            try
            {
                return Redirect(_smallUrlService.GetUrl(url));
            }
            catch (Exception ex)
            {
                TempData["message"] = "404 The Url Was Not Found Would Like To Try Again Or Make A New One";
                return Redirect("/Index");
            }


        }
    }
}
