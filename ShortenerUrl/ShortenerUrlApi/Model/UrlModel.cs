using System.ComponentModel.DataAnnotations;

namespace ShortenerUrlApi.Model
{
    public class UrlModel
    {
        [Required]
        public string Url { get; set; }
    }
}
