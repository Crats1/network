﻿using System.Runtime.CompilerServices;

namespace webapi.Data;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<NetworkAppContext>();
            context.Database.EnsureCreated();
            //DbInitialiser.Initialise(context);
        }
    }
}
