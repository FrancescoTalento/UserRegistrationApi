using Microsoft.AspNetCore.Identity;
using WebAPI.Data.DTO;
using WebAPI.Data.Models;
using WebAPI.Extensions;

namespace WebAPI.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;


        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
           this._userManager = userManager;
           this._signInManager = signInManager;
            this._tokenService = tokenService;
        }

        public async Task RegisterUser(CreateUserDto? createUser)
        {
            if(createUser is null) throw new ArgumentNullException(nameof(createUser));

            User userToRegister = createUser.ToEntity();

            IdentityResult result = await this._userManager.CreateAsync(userToRegister, createUser.Password);

            if (!result.Succeeded) { throw new ApplicationException("Error on registring User"); };
            return;

        }

        public async Task<string> LoginUser(LoginUserDto? loginUser)
        {
            if (loginUser is null) throw new ArgumentNullException(nameof(loginUser));

            User? user = await this._userManager.FindByNameAsync(loginUser?.Name);

            if(user is null) { throw new ApplicationException("Incorrect UserName"); };
            SignInResult result = await this._signInManager.PasswordSignInAsync(loginUser.Name, loginUser.Password, false, false);
            if (!result.Succeeded) { throw new ApplicationException("Password Incorrect"); };
            
            
            
            
            return _tokenService.GenerateToken(user); 
        }
    }
}
