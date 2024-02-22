using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class URLShortenerViewModel
    {
        public URLShortenerViewModel(Guid id, string url)
        {
            Id = id;
            Url = url;
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Url { get; set; }
    }
}

