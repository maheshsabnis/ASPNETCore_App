using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAppHome.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAppHome.Services
{
    public class EmployeeService : IService<Employee, int>
    {
        private readonly AppHomeDbContext ctx;

        public EmployeeService(AppHomeDbContext ctx)
        {
            this.ctx = ctx;
        }

        public  async Task<Employee> CreateAsync(Employee entity)
        {
            var res = await ctx.Employees.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await ctx.Employees.FindAsync(id);
            if (res != null)
            {
                ctx.Employees.Remove(res);
                await ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            return await ctx.Employees.ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await ctx.Employees.FindAsync(id);
        }

        public async Task<Employee> UpdateAsync(int id, Employee entity)
        {
            var res = await ctx.Employees.FindAsync(id);
            if (res != null)
            {
                res.EmpNo = entity.EmpNo;
                res.EmpName = entity.EmpName;
                res.Designation = entity.Designation;
                res.Salary = entity.Salary;
                res.DeptRowId = entity.DeptRowId;
                await ctx.SaveChangesAsync();
                return res;
            }
            return res;

        }
    }
}
