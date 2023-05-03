using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    [Keyless]
    public class UserLikesPosts
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
        public bool IsLiked { get; set; } = false;

        public ApplicationUser? User { get; set; }
        public Post? Post { get; set; }
    }
}
