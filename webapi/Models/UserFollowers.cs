using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [PrimaryKey(nameof(UserID), nameof(FollowerID))]
    public class UserFollowers
    {
        public int UserID { get; set; }
        public int FollowerID { get; set; }

        public ApplicationUser User { get; set; } = null!;
        public ApplicationUser Follower { get; set; } = null!;
    }
}
