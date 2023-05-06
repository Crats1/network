using Microsoft.AspNetCore.Identity;
using webapi.Models;

namespace webapi.Data;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            NetworkAppContext context = services.GetRequiredService<NetworkAppContext>();
            context.Database.EnsureCreated();
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            DbInitialiser.Initialise(context, userManager);
        }
    }
}
