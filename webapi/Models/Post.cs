using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required]
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public int UserID { get; set; }
    }
}
