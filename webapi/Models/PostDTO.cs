using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class PostDTO
    {
        public int ID { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public bool IsCreatedByUser { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
