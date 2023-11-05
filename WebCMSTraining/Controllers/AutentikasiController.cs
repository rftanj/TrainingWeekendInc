using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebCMSTraining.Context;
using WebCMSTraining.Models.DTO;
using WebCMSTraining.Helper;
using Microsoft.AspNetCore.Identity;
using WebCMSTraining.Models.DB;

namespace WebCMSTraining.Controllers
{
    public class AutentikasiController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AutentikasiController(AppDbContext context, RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //[SessionHelper]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email, Password")] User user)
        {
            
            if (ModelState.IsValid)
            {
                var GetUser = await _userManager.FindByEmailAsync(user.Email);

                if (GetUser != null)
                {
                    var GetRole = await _userManager.GetRolesAsync(GetUser);
                    if(GetRole.Contains("SuperAdmin"))
                    {
                        HttpContext.Session.SetString("User", GetUser.Name);
                        var result = await _signInManager.PasswordSignInAsync(GetUser, user.Password, false, false);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        ModelState.AddModelError(string.Empty, "Email Or Password is Invalid");
                    }

                    ModelState.AddModelError(string.Empty, "Email Or Password is Invalid");
                }
                
                ModelState.AddModelError(string.Empty, "Email Or Password is Invalid");
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login([Bind("Email, Password")] SuperAdminDTO superAdminDTO)
        //{
        //    //HttpContext.Session.SetString("Email", superAdminDTO.Email);

        //    if (ModelState.IsValid)
        //    {
        //        var SuperAdm = _context.SuperAdmins.Where(x => x.Email == superAdminDTO.Email && x.Password == superAdminDTO.Password)
        //                .FirstOrDefault();

        //        if (SuperAdm != null)
        //        {
        //            var Claims = new List<Claim>
        //            {
        //                new Claim("email",SuperAdm.Email),
        //                new Claim("password", SuperAdm.Password)
        //            };

        //            HttpContext.Session.SetString("Email", SuperAdm.Email);

        //            await HttpContext.SignInAsync(new ClaimsPrincipal(
        //                new ClaimsIdentity(Claims, "Cookies", "email", "password")
        //                ));

        //            return Redirect("/Home/Index");
        //        }
        //    }
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //HttpContext.Session.Clear();
            //await HttpContext.SignOutAsync();
            return RedirectToAction("Login");

        }

        public IActionResult Denied()
        {
            return View();
        }

    }
}
