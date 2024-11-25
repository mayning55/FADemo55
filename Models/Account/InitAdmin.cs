using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADemo.Models.Account
{
    /// <summary>
    /// 初始化Admin和一些用户信息，初始化完后可以删除。
    /// </summary>
    public class InitAdmin
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ExtendIdentityUser> userManager;


        public InitAdmin(UserManager<ExtendIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task Manage()
        {
            if (await roleManager.RoleExistsAsync("Admin") == false)
            {
                IdentityRole adminRole = new IdentityRole();
                adminRole.Name = "Admin";
                var result = await roleManager.CreateAsync(adminRole);
            }
            if (await roleManager.RoleExistsAsync("BaseInfoAdmin") == false)
            {
                IdentityRole normalUserRole = new IdentityRole();
                normalUserRole.Name = "BaseInfoAdmin";
                var result = await roleManager.CreateAsync(normalUserRole);
            }
            if (await roleManager.RoleExistsAsync("GeneralUser") == false)
            {
                IdentityRole normalUserRole = new IdentityRole();
                normalUserRole.Name = "GeneralUser";
                var result = await roleManager.CreateAsync(normalUserRole);
            }
            var userAdmin = await userManager.FindByNameAsync("Admin");
            if (userAdmin == null)
            {
                userAdmin = new ExtendIdentityUser()
                {
                    UserName = "Admin"
                };
                var result = await userManager.CreateAsync(userAdmin, "123456");
            }
            if (!await userManager.IsInRoleAsync(userAdmin, "Admin"))
            {
                var result = await userManager.AddToRoleAsync(userAdmin, "Admin");
            }
            if (!await userManager.IsInRoleAsync(userAdmin, "BaseInfoAdmin"))
            {
                var result = await userManager.AddToRoleAsync(userAdmin, "BaseInfoAdmin");
            }
            var user1= await userManager.FindByNameAsync("User1");
            if (user1 == null)
            {
                user1 = new ExtendIdentityUser()
                {
                    UserName = "User1"
                };
                var result = await userManager.CreateAsync(user1, "123456");
            }
            if (!await userManager.IsInRoleAsync(user1, "BaseInfoAdmin"))
            {
                var result = await userManager.AddToRoleAsync(user1, "BaseInfoAdmin");
            }
        }
    }
}
