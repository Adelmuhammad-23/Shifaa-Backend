using AutoMapper;
using ShifaaAPI.AppMetaData;
using ShifaaAPI.DTO;
using ShifaaAPI.Models.Identity;
using ShifaaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ShifaaAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IRegisterServies _applicationUserServies;
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructors
        // Constructor for injecting dependencies
        public AccountController(IMapper mapper,
                                  IRegisterServies applicationUserServices, ILoginService loginService, IConfiguration configuration)
        {
            _mapper = mapper;
            _applicationUserServies = applicationUserServices;
            _loginService = loginService;
            _configuration = configuration;
        }
        #endregion

        #region Controllers
        [HttpPost(Router.AccountRouting.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            // Mapping the AddUserCommandDTO to a User entity using AutoMapper
            var UserMapping = _mapper.Map<User>(register);

            // Calling the service to add the user and await the result
            var emailResult = await _applicationUserServies.AddUserAsync(UserMapping, register.Password);

            // Handling the result of the user addition
            switch (emailResult)
            {
                case "EmailIsExist":
                    return BadRequest("Email Is already Exist");
                case "Failed":
                    return BadRequest("Failed To Register ");
                case "Success":
                    return Ok("Register has been completed successfully");
                default:
                    return BadRequest();
            }
        }

        [HttpPost(Router.AccountRouting.Login)]

        public async Task<IActionResult> Login(LoginDTO login)
        {
            // Calling the service to log the user in and await the result
            var loginResult = await _loginService.LogUserAsync(login.Email, login.Password);

            // Handling the result of the user login
            switch (loginResult)
            {
                case "EmailIsNotExist":
                    return BadRequest("Email Does Not Exist");
                case "PasswordIsNotCorrect":
                    return BadRequest("Password Is Not Correct");
                case "Failed":
                    return BadRequest("Failed To Login ");
                case "Success":
                    var token = GenerateJwtToken(login.Email);
                    return Ok(new { Message = "Login successful", Token = token });

                    //return Ok("Login has been completed successfully");
                default:
                    return BadRequest();


                   
            }
        }

        private string GenerateJwtToken(string email)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            // Define the token's claims
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Email, email)
    };

            // Generate the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiry time
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }
}
