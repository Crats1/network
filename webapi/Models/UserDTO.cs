namespace webapi.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public bool IsFollowing { get; set; }

        public UserDTO(ApplicationUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            FollowerCount = user.Followers.Count;
            FollowingCount = user.Follows.Count;
        }
    }
}
