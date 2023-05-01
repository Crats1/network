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

            var users = new User[]
            {
                new User{ Username="test1", PasswordHash="test" },
                new User{ Username="test2", PasswordHash="test" },
                new User{ Username="test3", PasswordHash="test" },
                new User{ Username="test4", PasswordHash="test" },
                new User{ Username="test5", PasswordHash="test" },
            };

            context.Users.AddRange(users);
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
