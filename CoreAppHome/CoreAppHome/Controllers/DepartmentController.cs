using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreAppHome.Models;
using CoreAppHome.Services;
namespace CoreAppHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IService<Department, int> service;
        public DepartmentController(IService<Department, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = service.GetAsync().Result;
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = service.GetAsync(id).Result;
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Post(Department data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (data.Capacity <= 0) throw new Exception("Capacity cannot be -Ve or Zero");
                    var res = service.CreateAsync(data).Result;
                    return Ok(res);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Department data)
        {
            try
            {
                if (id != data.DeptRowId) throw new Exception("Parameter Does not Match from Search with body");
                if (ModelState.IsValid)
                {
                    if (data.Capacity <= 0) throw new Exception("Capacity cannot be -Ve or Zero");
                    var res = service.UpdateAsync(id, data).Result;
                    return Ok(res);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.DeleteAsync(id).Result;
            if (!res) return NotFound($"Record based on {id} is either removed or does not exist");
            return Ok(res);
        }
    }
}