using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.DTO;
using WebAPI.Data.Models;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userMangaer; 

        public UserController(UserManager<User> userManager)
        {
            this._userMangaer = userManager;
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> RegisterUser(CreateUserDto? createUser)
        {
            if(createUser == null) throw new ArgumentNullException(nameof(createUser));
            var user = createUser.ToEntity();

            IdentityResult result = await this._userMangaer.CreateAsync(user, createUser.Password);

            if(result.Succeeded) { return Ok(User); };

            return Problem("Error on registring new user");
        }
    }


}
