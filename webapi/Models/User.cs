using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public ICollection<Post>? Posts { get; set; }
        //public ICollection<UserFollowers>? Followers { get; set; }
        //public ICollection<UserLikesPosts>? LikedPosts { get; set; }
    }
}
