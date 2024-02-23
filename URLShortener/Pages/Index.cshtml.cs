using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using URLShortener.Services;

namespace URLShortener.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IURLShortenerService _smallUrlService;
        private readonly ILogger<IndexModel> _logger;
       


        public IndexModel(IURLShortenerService service, ILogger<IndexModel> logger)
        {
            _smallUrlService = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger;
        }


        public void OnPost()
        {  
            
            string url = Request.Form[nameof(Url)];

                try
                {
                    ViewData["returnedUrl"] = _smallUrlService.PostUrl(url);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

            
        }
    }
}