using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PeopleBookAPI.Entities;
using PeopleBookAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PeopleBookAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto userDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            user.Username = userDto.Username;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto userDto)
        {
            // search in db
            if (user.Username !=  userDto.Username)
            {
                return BadRequest("Wrong username or password.");
            }

            if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
            {
                return BadRequest("Wrong username or password.");
            }

            string token = CreateToken(user);

            return Ok(token);    
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
               new (ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
