using App.Service.Commands;
using App.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiToken.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class AuthController : ControllerBase
    {
        //static readonly List<User> users = new List<User>(); 
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("signup")]

        public async Task<IActionResult> SignUp([FromBody] SignUp user)
        {
            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            //user.PasswordHash = hashedPassword;



            //users.Add(user);

            //return Ok(new { message = "User registered successfully" });

            var result = await _userService.SignUp(user);
            return Ok(result);
        }


        [HttpPost("login")]

        public async Task<IActionResult> SignIn([FromBody] App.Service.Commands.SignIn user)
        {

            // var existingUser = users.SingleOrDefault(u => /*u.Username == user.Username && */u.PasswordHash == user.PasswordHash && u.Email == user.Email);
            //if (existingUser == null)
            //{
            //    return Unauthorized(new { message = "Invalid information." });
            //}

            //var token = GenerateJwtToken(existingUser);
            //return Ok(new { token });
            var result = await _userService.SignIn(user);
            if (result)
            {
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }
            return Unauthorized(new { message = "Invalid login or  disactivated account " });

        }

        [HttpDelete("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteProfile([FromBody] DeleteUser user)
        {
         
            var result = await _userService.DeleteProfile(user);
            return Ok(new { message = "Profile deleted" });
            
        }



        [HttpGet("me")]
        [Authorize]
        public   IActionResult CurrentUser()
        {
            var currentUser =  GetCurrentUser();
            return Ok($"Hi you are  {currentUser.Email}");
        }
        private SignIn GetCurrentUser()
        {
            var identity =  HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims =  identity.Claims;
                return new SignIn
                {
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                };
            }
            return null;
        }

        private string GenerateJwtToken(App.Service.Commands.SignIn user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Authentication,user.Password)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}