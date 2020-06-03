using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourseSelect.Models;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Services.Interfaces;
using System.Security.Claims;
using Infrastructure.Services.Implementations;

namespace CourseSelect.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersService _usersService;


        public HomeController(ILogger<HomeController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult DvvsModify()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _usersService.GetUserById(userId);
            if(user.IsAdmin==true)
            {
                var model = new DvvsModel();
                var users = _usersService.GetUsers();
                model.Teachers = users;
                return View(model);
            }
            return RedirectToAction("CourseList","Course");
            
        }
    }

}
