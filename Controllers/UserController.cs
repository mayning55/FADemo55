﻿using FADemo.Models.Account;
using FADemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace FADemo.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>

    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ExtendIdentityUser> userManager;

        private readonly SignInManager<ExtendIdentityUser> signInManager;

        private readonly ApplicationDbContext context;

        public UserController(UserManager<ExtendIdentityUser> userManager,
            SignInManager<ExtendIdentityUser> signInManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context; 
        }
        /// <summary>
        /// 在创建时，检查用户名是否已经存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> IsUserNameAvailable(string UserName)
        {
            var user = await userManager.FindByNameAsync(UserName);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"UserName {UserName} is already in use.");
            }
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser createUser)
        {
            if (ModelState.IsValid)
            {
                var user = new ExtendIdentityUser
                {
                    UserName = createUser.UserName,
                };

                var result = await userManager.CreateAsync(user, createUser.Password);

                if (result.Succeeded)
                {
                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers");
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(createUser);
        }


        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }
        /// <summary>
        /// 禁用用户，IsDisabled属性为真，视图界面根据此判断图标字样
        /// 并将用户锁定时间设为最大。
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IActionResult> DisableUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.IsDisabled = true;
                await userManager.UpdateAsync(user);
                var result1 = await userManager.SetLockoutEnabledAsync(user, true);
                var result = await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View("ListUsers");
            }
        }
        /// <summary>
        /// 启用用户，跟禁用相反
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IActionResult> EnableUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.IsDisabled = false;
                await userManager.UpdateAsync(user);
                await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
            }

            return RedirectToAction("ListUsers");
        }

        [HttpGet]
        public async Task<IActionResult> ResetUserPassword(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var resetPassword = new ResetUserPassword
            {
                Id = user.Id,
                UserName = user.UserName,
            };

            return View(resetPassword);
        }
        /// <summary>
        /// 重置用户密码（先移除密码，再添加密码）
        /// </summary>
        /// <param name="resetUserPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ResetUserPassword(ResetUserPassword resetUserPassword)
        {
            var user = await userManager.FindByIdAsync(resetUserPassword.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {resetUserPassword.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.RemovePasswordAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, resetUserPassword.Password);
                    return RedirectToAction("ListUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View(resetUserPassword);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var userRoles = await userManager.GetRolesAsync(user);

            var editUser = new EditUser
            {
                Id = user.Id,
                UserName = user.UserName,
                DepartmentId = user.DepartmentId,
                Roles = userRoles
            };
            ViewData["DepartmentId"] = new SelectList(context.Departments, "DepartmentId", "DepartmentName", user.DepartmentId);

            return View(editUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUser editUser)
        {
            var user = await userManager.FindByIdAsync(editUser.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {editUser.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.UserName = editUser.UserName;
                user.DepartmentId = editUser.DepartmentId;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View(editUser);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View("ListUsers");
            }
        }
    }
}
