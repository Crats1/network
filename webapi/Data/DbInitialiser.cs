using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class DbInitialiser
    {
        public static void Initialise(NetworkAppContext context)
        {
            // Database has already been seeded
            if (context.Posts.Any())
            {
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Posts\" RESTART IDENTITY");
                //return;
            }
            if (context.Users.Any()) context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Users\" RESTART IDENTITY CASCADE");

            //var users = new ApplicationUser[]
            //{
            //    new ApplicationUser{ Id = 1, UserName="test1", PasswordHash="test" },
            //    new ApplicationUser{ Id = 2, UserName="test2", PasswordHash="test" },
            //    new ApplicationUser{ Id = 3, UserName="test3", PasswordHash="test" },
            //    new ApplicationUser{ Id = 4, UserName="test4", PasswordHash="test" },
            //    new ApplicationUser{ Id = 5, UserName="test5", PasswordHash="test" },
            //};
            var users = new ApplicationUser[]
            {
                new ApplicationUser{ UserName="test1" },
                new ApplicationUser{ UserName="test2" },
                new ApplicationUser{ UserName="test3" },
                new ApplicationUser{ UserName="test4" },
                new ApplicationUser{ UserName="test5" },
            };

            //context.Users.AddRange(users);
            context.SaveChanges();

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
    }
}
