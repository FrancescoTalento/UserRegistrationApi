using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Models;

namespace WebAPI.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext<User>(options)
    {
        //public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        
            
        
    }
}
