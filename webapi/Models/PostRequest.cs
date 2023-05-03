using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class PostRequest
    {
        [Required]
        public string Content { get; set; } = null!;
    }
}
