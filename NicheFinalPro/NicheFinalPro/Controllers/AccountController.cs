using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NicheFinalPro.Data;
using NicheFinalPro.Models;
using Microsoft.AspNetCore.Http;
using NicheFinalPro.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NicheFinalPro.Controllers
{
    public class AccountController : Controller
    {
        
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {

            if (this.User.Identity.IsAuthenticated)
            {
                //HttpContext.Session.SetString("uname", this.User.Identity.Name);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Events");
                }
            }
            ModelState.AddModelError("", "Failed to Login");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    UserName = registerModel.UserName,
                    Email = registerModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToRoute("Home","Index");
        }
        [HttpGet]
        public async Task<IActionResult> Account()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                string userid = HttpContext.User.Identity.Name;
                var user = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == userid);
                return View(user);
                //HttpContext.Session.SetString("uname", this.User.Identity.Name);
                //return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
