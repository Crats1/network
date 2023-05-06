using Microsoft.AspNetCore.Identity;
using webapi.Models;

namespace webapi.Data
{
    public class DbInitialiser
    {
        public static async void Initialise(NetworkAppContext context, UserManager<ApplicationUser> userManager)
        {
            if (!context.Users.Any())
            {
                await userManager.CreateAsync(new ApplicationUser{ UserName="test1" }, "password1");
                await userManager.CreateAsync(new ApplicationUser{ UserName="test2" }, "password1");
                await userManager.CreateAsync(new ApplicationUser{ UserName="test3" }, "password1");
                await userManager.CreateAsync(new ApplicationUser{ UserName="test4" }, "password1");
                await userManager.CreateAsync(new ApplicationUser{ UserName="test5" }, "password1");
            }

            if (!context.Posts.Any() && context.Users.Count() >= 4)
            {
                var posts = new Post[]
                {
                    new Post{ Content = "Test content 1", UserID = 1 },
                    new Post{ Content = "Test content 1.1", UserID = 1 },
                    new Post{ Content = "Test content 1.2", UserID = 1 },
                    new Post{ Content = "Test content 1.3", UserID = 1 },
                    new Post{ Content = "Test content 1.4", UserID = 1 },
                    new Post{ Content = "Test content 1.5", UserID = 1 },
                    new Post{ Content = "Test content 2", UserID = 2 },
                    new Post{ Content = "Test content 3", UserID = 3 },
                    new Post{ Content = "Test content 4", UserID = 4 },
                };

                context.Posts.AddRange(posts);
                context.SaveChanges();
            }

            if (!context.UserFollowers.Any() && context.Users.Count() >= 4)
            {
                var followers = new UserFollowers[]
                {
                    new UserFollowers { UserID = 1, FollowerID = 2 },
                    new UserFollowers { UserID = 1, FollowerID = 3 },
                    new UserFollowers { UserID = 1, FollowerID = 4 },
                    new UserFollowers { UserID = 2, FollowerID = 1 },
                };

                context.UserFollowers.AddRange(followers);
                context.SaveChanges();
            }

            if (!context.UsersLikesPosts.Any() && context.Users.Count() >= 4)
            {
                var likes = new UserLikesPosts[]
                {
                    new UserLikesPosts { UserID = 1, PostID = 1 },
                    new UserLikesPosts { UserID = 1, PostID = 2 },
                    new UserLikesPosts { UserID = 1, PostID = 3 },
                    new UserLikesPosts { UserID = 1, PostID = 4 },
                    new UserLikesPosts { UserID = 2, PostID = 1 },
                };

                context.UsersLikesPosts.AddRange(likes);
                context.SaveChanges();
            }
        }
    }
}
