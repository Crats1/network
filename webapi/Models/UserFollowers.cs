﻿using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class UserFollowers
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserId")]
        public int FollowerID { get; set; }

        public ApplicationUser User { get; set; } = null!;
        [ForeignKey("FollowerID")]
        public ApplicationUser Follower { get; set; } = null!;
    }
}
