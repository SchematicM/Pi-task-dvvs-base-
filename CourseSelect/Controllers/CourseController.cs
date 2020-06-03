using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CourseSelect.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly IDBBCService _dBBCService;
        private readonly IUsersService _usersService;
        private readonly IDBBCToUserService _dBBCToUserService;

        public CourseController(
            IDBBCService dBBCService,
            IUsersService usersService,
            IDBBCToUserService dBBCToUserService)
        {
            _dBBCService = dBBCService;
            _usersService = usersService;
            _dBBCToUserService = dBBCToUserService;
        }

        public IActionResult CourseList()
        {
            var dbbcs = _dBBCService.GetDBBC();
            return View(dbbcs);
        }


        public IActionResult Course(Dbbc model)
        {
            var teacher = _usersService.GetUserById(model.TeacherId);

            model.Teacher = teacher;

            return View(model);
        }

        public IActionResult MyCourses()
        {
            var dbbcsToUser = _dBBCToUserService.GetUsersDbbcByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var dbbcs = new List<Dbbc>();

            foreach (var item in dbbcsToUser)
            {
                dbbcs.Add(_dBBCService.GetById(item.Dbbcid));
            }

            return View(dbbcs);
        }
    }
}