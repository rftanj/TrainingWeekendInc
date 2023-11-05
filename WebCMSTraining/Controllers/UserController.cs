using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCMSTraining.Context;
using WebCMSTraining.Helper;
using WebCMSTraining.Models.DB;
using WebCMSTraining.Models.DTO;

namespace WebCMSTraining.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public UserController(UserManager<User> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {

            var getRoles = await _roleManager.FindByNameAsync("User");

            if (getRoles is null)
            {
                return NotFound("Role is Not Found");
            }

            var getUserRole = await _userManager.GetUsersInRoleAsync(getRoles.Name);

            //var GetData = _context.Users.ToList();

            return View(getUserRole);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([Bind("Name, Email, Password, Phone, Address, Password")]RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                User existingUser = await _userManager.FindByEmailAsync(registerDTO.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError("Email","Email Already Exist");
                }

                User user = new User
                {
                    Email = registerDTO.Email,
                    Address = registerDTO.Address,
                    PhoneNumber = registerDTO.Phone,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = registerDTO.Name,
                    UserName = registerDTO.Name
                };

                IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                           await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    await _userManager.AddToRoleAsync(user, UserRoles.User);


                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View();
        }

        public async Task<IActionResult> UpdateUser(string Id)
        {
            var GetUser = await _userManager.FindByIdAsync(Id);
            return View(GetUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser([Bind("Id, Name, Email, Password, PhoneNumber, Address, Password, Status")] User user)
        {
            var GetUser = await _userManager.FindByIdAsync(user.Id);

            if (ModelState.IsValid)
            {
                if (GetUser is null)
                {
                    return NotFound("Data is Not Found");
                }

                if (user.Password is null)
                {
                    GetUser.Name = user.Name;
                    GetUser.Email = user.Email;
                    GetUser.Address = user.Address;
                    GetUser.PhoneNumber = user.PhoneNumber;
                    GetUser.Status = user.Status;
                }
                else
                {
                    GetUser.Name = user.Name;
                    GetUser.Email = user.Email;
                    GetUser.Address = user.Address;
                    GetUser.PhoneNumber = user.PhoneNumber;
                    GetUser.Password = user.Password;
                    GetUser.Status = user.Status;
                }

                var result = await _userManager.UpdateAsync(GetUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var GetUser = await _userManager.FindByIdAsync(Id);
            if (GetUser is null)
            {
                return NotFound();
            }

            GetUser.Status = Models.DB.User.UserStatus.Trash;

            var result = await _userManager.UpdateAsync(GetUser);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
