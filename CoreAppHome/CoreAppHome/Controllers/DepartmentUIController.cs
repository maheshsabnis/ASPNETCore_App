using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAppHome.Models;
using CoreAppHome.Services;
namespace CoreAppHome.Controllers
{
    public class DepartmentUIController : Controller
    {
        private readonly IService<Department, int> service;
        public DepartmentUIController(IService<Department, int> service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var depts = service.GetAsync().Result;
            return View(depts);
        }


        public IActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            //try
            //{

                if (ModelState.IsValid)
                {
                    if (dept.Capacity <= 0)
                    {
                        throw new Exception("Capacity Cannot be Zero or -Ve");
                    }
                    dept = service.CreateAsync(dept).Result;
                    return RedirectToAction("Index");
                }
                return View(dept);
            //}
            //catch (Exception ex)
            //{
            //    return View("Error",
            //          new ErrorViewModel()
            //          {
            //               ControllerName=this.RouteData.Values["controller"].ToString(),
            //               ActionName = this.RouteData.Values["action"].ToString(),
            //               ErrorMessage = ex.Message
            //          });
            //}
        }
    }
}