using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data;

public class NetworkAppContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public NetworkAppContext(DbContextOptions<NetworkAppContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<UserFollowers> UserFollowers { get; set; }
    public DbSet<UserLikesPosts> UsersLikesPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<UserFollowers>()
            .HasOne(e => e.User)
            .WithMany(e => e.Followers);
        builder.Entity<UserFollowers>()
            .HasOne(e => e.Follower)
            .WithMany(e => e.Follows)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
