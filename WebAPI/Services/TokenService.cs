using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;
using WebAPI.Data.DTO;
using WebAPI.Data.Models;

namespace WebAPI.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string GenerateToken(User user)
        {

            var claimns = new Dictionary<string,object>()
            {
                ["username"] = user.UserName,
                ["id"] = user.Id,
                [ClaimTypes.DateOfBirth] = user.DateOfBirth.ToString(),
                
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Key"]!));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddMinutes(10),
                Claims = claimns,
                SigningCredentials = signingCredentials
            };

            var handler = new JsonWebTokenHandler();
            return handler.CreateToken(token);
            
        }
    }
}