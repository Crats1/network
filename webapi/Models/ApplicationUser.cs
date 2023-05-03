using Microsoft.AspNetCore.Identity;

namespace webapi.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        //public ICollection<UserFollowers>? Followers { get; set; }
        public ICollection<UserLikesPosts> UserLikesPosts { get; set; } = new List<UserLikesPosts>();
    }
}
