namespace webapi.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public int UserID { get; set; }
    }
}
