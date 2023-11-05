using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebTrainingWEEKEND.Helper;
using WebTrainingWEEKEND.Models;
using WebTrainingWEEKEND.Models.DTO;

namespace WebTrainingWEEKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        //[HttpPost]
        //[Authorize(Roles = UserRoles.User)]
        //public async Task<IActionResult> GetId()
        //{

        //    var user = await _userManager.FindByIdAsync(User.Identity.Name);

        //    //return new(
        //    //{
        //    //    IsAuthenticated = User.Identity.IsAuthenticated,
        //    //    Id = User.Identity.Name,
        //    //    //Name = $"{user.FirstName} {user.LastName}",
        //    //    Type = User.Identity.AuthenticationType,
        //    //});

        //    var UserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        //    var ss = _userManager.


        //    var UserName = User.FindFirstValue(ClaimTypes.Name);//  <<<== work


        //    return Ok(new ResponseDTO()
        //    {
        //        Status = user.UserName,
        //        Message = user.Email
        //    });
        //}


        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDTO register)
        {
            User existingUser = await _userManager.FindByNameAsync(register.UserName);

            if (existingUser != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, 
                    new ResponseDTO() { Status = "Error", Message = "User Already Exists!" });
            }

            User user = new User()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.UserName
                
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new ResponseDTO() { Status = "Error", Message = "User Creation Failed! Please Try Again.." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            await _userManager.AddToRoleAsync(user, UserRoles.Admin);

            return Ok(new ResponseDTO() { Status = "Success", Message = "User Created!" });
        }

        [HttpPost]
        [Route(("register-user"))]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            User existingUser = await _userManager.FindByNameAsync(dto.UserName);

            if (existingUser != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ResponseDTO() { Status = "Error", Message = "User Already Exists!" });
            }

            User user = new User()
            {
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = dto.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO { Status = "Error", Message = "User Creation Failed! Please Try Again.." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            await _userManager.AddToRoleAsync(user, UserRoles.User);

            return Ok(new ResponseDTO() { Status = "Success", Message = "User Created" });
        }

        [HttpPost]
        [Route("register-driver")]
        public async Task<IActionResult> RegisterDriver([FromBody] RegisterDTO register)
        {
            User existingUser = await _userManager.FindByNameAsync(register.UserName);

            if (existingUser != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ResponseDTO() { Status = "Error", Message = "User Already Exists!" });
            }

            User user = new User()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO() { Status = "Error", Message = "User Creation Failed! Please Try Again.." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Driver))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Driver));

            await _userManager.AddToRoleAsync(user, UserRoles.Driver);

            return Ok(new ResponseDTO() { Status = "Success", Message = "User Created!" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            User user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null) return Unauthorized();
            if (await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    expires: DateTime.Now.AddHours(24),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            else return Unauthorized(new ResponseDTO() { Status = "Error", Message = "Please, Login Again" });
        }

    }
}
