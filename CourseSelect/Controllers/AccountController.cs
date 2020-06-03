using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CourseSelect.Areas.Identity.Pages.Account;
using CourseSelect.Models;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CourseSelect.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signInManager;
        private readonly IUsersService _usersService;

        public AccountController(
            UserManager<AspNetUsers> userManager,
            SignInManager<AspNetUsers> signInManager,
            IUsersService usersService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usersService = usersService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Registering";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AspNetUsers user = new AspNetUsers
                {
                    UserName = model.Name,
                    Surname = model.Surname,
                    Credit = model.Credit,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("CourseList", "Course");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var users = _usersService.GetUserByCredit(model.Credit);

                if (users.Count() == 1)
                {
                    var user = users.ToList()[0];
                    PasswordVerificationResult result = new PasswordHasher<AspNetUsers>().VerifyHashedPassword(user, user.PasswordHash, model.Password);
                    if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
                    {
                        await _signInManager.SignInAsync(users.ToList()[0], false);
                        return RedirectToAction("CourseList", "Course");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Wrong password");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Credit");
                }

            }

            return Redirect("~/Identity/Account/Login");
        }
    }
}