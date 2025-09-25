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
        public string GenerateToken(User user)
        {

            var claimns = new Dictionary<string,object>()
            {
                ["username"] = user.UserName,
                ["id"] = user.Id,
                [ClaimTypes.DateOfBirth] = user.DateOfBirth.ToString(),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("afosiun8q28b2b18b8qfb2fq1b8akjsdnjad"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);

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