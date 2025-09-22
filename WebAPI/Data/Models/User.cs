using Microsoft.AspNetCore.Identity;

namespace WebAPI.Data.Models
{
    public class User : IdentityUser
    {
        public DateOnly DateOfBirth { get; set; }
    }
}
