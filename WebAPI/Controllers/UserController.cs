using Microsoft.AspNetCore.Authorization;
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
        private readonly UserService userService;
        

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> RegisterUser([FromBody]CreateUserDto? createUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await userService.RegisterUser(createUser);

            return Ok();
        }
        

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto? loginUserDto)
        {
            if (loginUserDto == null) return BadRequest();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var token = await this.userService.LoginUser(loginUserDto);

           return Ok(token);
        }


    }

}
