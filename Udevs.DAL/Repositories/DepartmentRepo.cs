using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_WebApplication_7039.DAL;
using WAD_WebApplication_7039.DAL.DBO;

namespace Udevs.DAL.Repositories
{
    public class DepartmentRepo : BaseRepo, IRepository<Department>
    {
        public DepartmentRepo(UdevsDbContext context)
            : base(context)
        {
        }

        public Task CreateAsync(Department entity)
        {
            _context.Add(entity);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public Task<List<Department>> GetAllAsync()
        {
            return _context.Departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Department entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
