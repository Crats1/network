namespace webapi.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Post>? Posts { get; set; }
        //public ICollection<UserFollowers>? Followers { get; set; }
        //public ICollection<UserLikesPosts>? LikedPosts { get; set; }
    }
}
