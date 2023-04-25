//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace SampleWebApi.Controllers
//{
//    [Route("api/token")]
//    [ApiController]
//    public class TokenController : ControllerBase
//    {
//        public IConfiguration _configuration;
//        private readonly IAuthenticationService _authenticationService;

//        public TokenController(IConfiguration config, IAuthenticationService authenticationService)
//        {
//            _configuration = config;
//            _authenticationService = authenticationService;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post(UserInfo _userData)
//        {
//            if (_userData != null && _userData.Email != null && _userData.Password != null)
//            {
//                var user = await _authenticationService.GetUser(_userData.Email, _userData.Password);

//                if (user != null)
//                {
//                    //create claims details based on the user information
//                    var claims = new[] {
//                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
//                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
//                        new Claim("UserId", user.UserId.ToString()),
//                        new Claim("DisplayName", user.DisplayName),
//                        new Claim("UserName", user.UserName),
//                        new Claim("Email", user.Email)
//                    };

//                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//                    var token = new JwtSecurityToken(
//                        _configuration["Jwt:Issuer"],
//                        _configuration["Jwt:Audience"],
//                        claims,
//                        expires: DateTime.UtcNow.AddMinutes(10),
//                        signingCredentials: signIn);

//                    var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

//                    var result = new JwtResult
//                    {
//                        token = accessToken,
//                        success = true
//                    };

//                    return Ok(result);
//                }
//                else
//                {
//                    return BadRequest("Invalid credentials");
//                }
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }
//    }
//}
