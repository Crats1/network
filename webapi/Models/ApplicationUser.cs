using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ICollection<Post>? Posts { get; set; }
        //public ICollection<UserFollowers>? Followers { get; set; }
        //public ICollection<UserLikesPosts>? LikedPosts { get; set; }
    }
}
