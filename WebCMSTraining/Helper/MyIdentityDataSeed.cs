using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCMSTraining.Models.DB;

namespace WebCMSTraining.Helper
{
    public static class MyIdentityDataSeed
    {
        public static void SeedData (UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            SeedUsers(_userManager);
            SeedRoles(_roleManager);
        }

        public static async void SeedUsers (UserManager<User> _userManager)
        {
            if (_userManager.FindByNameAsync("Admin").Result == null)
            {
                User user = new User
                {
                    Name = "Admin",
                    UserName = "Admin",
                    Email = "admin@weekendinc.com",
                    Status = User.UserStatus.Published
                };

                IdentityResult result = await _userManager.CreateAsync(user, "Admin@123");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "SuperAdmin");
                }
            }
        }

        public static async void SeedRoles (RoleManager<IdentityRole> _roleManager)
        {
            if (!_roleManager.RoleExistsAsync("SuperAdmin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "SuperAdmin";

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }
        }
    }
}
