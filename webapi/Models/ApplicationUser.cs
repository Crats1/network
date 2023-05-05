using Microsoft.AspNetCore.Identity;

namespace webapi.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<UserLikesPosts> UserLikesPosts { get; set; } = new List<UserLikesPosts>();
        public ICollection<UserFollowers> Follows { get; set; } = new List<UserFollowers>();
        public ICollection<UserFollowers> Followers { get; set; } = new List<UserFollowers>();
    }
}
