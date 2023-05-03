using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [PrimaryKey(nameof(UserID), nameof(PostID))]
    public class UserLikesPosts
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
        public bool IsLiked { get; set; } = true;

        public ApplicationUser User { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
