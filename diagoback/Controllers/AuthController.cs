using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using diagoback.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Data.SqlClient;
using SshNet.Security.Cryptography;

namespace diagoback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly diagodbContext _context;

        public AuthController(diagodbContext context, IConfiguration config)

        {
            _config = config;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Users login)
        {
            IActionResult response = Unauthorized();
            Users user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                user.RememberToken = tokenString;
                response = Ok(user);
            }
            return response;
        }

        private string GenerateJSONWebToken(Users userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Users AuthenticateUser(Users login)
        {
            Users user = null;
            var email = login.Email;
            var studentList = _context.Users.FromSqlRaw($"SELECT * FROM users where email='{email}'").ToList();
            foreach(Users userItem in studentList)
            {
               if (userItem.Password == login.Password)
                {
                    user = userItem;
                    return user;
                }
            }
            return user;
        }
        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
