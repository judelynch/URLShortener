using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class URLStringIdViewModel
    {
        public URLStringIdViewModel(string id, string url)
        {
            Id = id;
            Url = url;
        }
        [Key]
        [MaxLength(5)]
        public string Id { get; set; }
        [Required]
        public string Url { get; set; }
    }
}

