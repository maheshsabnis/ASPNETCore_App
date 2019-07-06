using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace CoreAppHome.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }


        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            var res = roleManager.CreateAsync(role).Result;
            return RedirectToAction("Index");
        }

    }
}