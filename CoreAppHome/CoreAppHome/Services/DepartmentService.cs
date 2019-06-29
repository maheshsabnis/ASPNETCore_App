using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAppHome.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAppHome.Services
{
    public class DepartmentService : IService<Department, int>
    {
        private readonly AppHomeDbContext ctx;

        public DepartmentService(AppHomeDbContext ctx)
        {
            this.ctx = ctx;
        }

        public  async Task<Department> CreateAsync(Department entity)
        {
            var res = await ctx.Departments.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await ctx.Departments.FindAsync(id);
            if (res != null)
            {
                ctx.Departments.Remove(res);
                await ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Department>> GetAsync()
        {
            return await ctx.Departments.ToListAsync();
        }

        public async Task<Department> GetAsync(int id)
        {
            return await ctx.Departments.FindAsync(id);
        }
         
        public async Task<Department> UpdateAsync(int id, Department entity)
        {
            var res = await ctx.Departments.FindAsync(id);
            if (res != null)
            {
                res.DeptNo = entity.DeptNo;
                res.DeptName = entity.DeptName;
                res.Location = entity.Location;
                res.Capacity = entity.Capacity;
                await ctx.SaveChangesAsync();
                return res;
            }
            return res;

        }
    }
}
