using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserDto createUser)
        {
            throw new NotImplementedException();    
        }
    }


}
