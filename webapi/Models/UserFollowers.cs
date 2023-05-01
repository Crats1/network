using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class UserFollowers
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserId")]
        public int FollowerID { get; set; }

        public User? User { get; set; }
        [ForeignKey("FollowerID")]
        public User? Follower { get; set; }
    }
}
