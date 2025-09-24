using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using WebAPI.Data.DTO;
using WebAPI.Data.Models;
using WebAPI.Extensions;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterService _registerService; 

        public UserController(RegisterService registerService)
        {
            this._registerService = registerService;
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> RegisterUser(CreateUserDto? createUser)
        {
            if(createUser == null) return BadRequest();
            if (!ModelState.IsValid) { return BadRequest(ModelState); };


            bool result = await this._registerService.RegisterUser(createUser);

            if(result) { return Ok(User); };

            return Problem("Error on registring new user");
        }
    }


}
