using Microsoft.AspNetCore.Mvc;
using URLShortener.Services;

namespace URLShortener.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
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
            return Redirect(_smallUrlService.GetUrl(url));


        }
    }
}
