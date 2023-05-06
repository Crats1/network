using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class PostDTO
    {
        public PostDTO(Post post, int userId)
        {
            ID = post.ID;
            Content = post.Content;
            CreatedAt = post.CreatedAt;
            UpdatedAt = post.UpdatedAt;
            IsCreatedByUser = userId == post.UserID;
            UserId = post.UserID;
            Username = post.User.UserName;
            IsLikedByUser = post.UserLikesPosts.FirstOrDefault(entry => entry.UserID == userId) != null;
            Likes = post.UserLikesPosts.Count();
        }

        public int ID { get; set; }
        [Required]
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsCreatedByUser { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public bool IsLikedByUser { get; set; }
        public int Likes { get; set; }
    }
}
