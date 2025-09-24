using Microsoft.AspNetCore.Identity;
using WebAPI.Data.DTO;
using WebAPI.Data.Models;
using WebAPI.Extensions;

namespace WebAPI.Services
{
    public class RegisterService
    {
        private readonly UserManager<User> _userManager;

        public RegisterService(UserManager<User> userManager)
        {
           this._userManager = userManager;
        }

        public async Task<bool> RegisterUser(CreateUserDto? createUser)
        {
            if(createUser is null) throw new ArgumentNullException(nameof(createUser));

            User userToRegister = createUser.ToEntity();

            IdentityResult result = await this._userManager.CreateAsync(userToRegister, createUser.Password);

            return result.Succeeded;

        }
    }
}
