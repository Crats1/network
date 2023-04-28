using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data;

public class NetworkAppContext : DbContext
{
    public NetworkAppContext(DbContextOptions<NetworkAppContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    //public DbSet<UserFollowers> UsersFollowers { get; set; }
    //public DbSet<UserLikesPosts> UsersLikesPosts { get; set; }

}
