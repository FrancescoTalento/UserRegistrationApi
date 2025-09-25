using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessController : ControllerBase
    {

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok("Acesso permitido");
        }
    }
}
