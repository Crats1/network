using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data;

//public class NetworkAppContext : DbContext
public class NetworkAppContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public NetworkAppContext(DbContextOptions<NetworkAppContext> options) : base(options) { }

    //public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    //public DbSet<UserFollowers> UsersFollowers { get; set; }
    //public DbSet<UserLikesPosts> UsersLikesPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
