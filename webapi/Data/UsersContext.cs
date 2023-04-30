using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webapi.Data;

public class UsersContext : IdentityUserContext<IdentityUser>
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
}
