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
    public class EmployeeRepo : BaseRepo, IRepository<Employee>
    {
        public EmployeeRepo(UdevsDbContext context)
            : base(context)
        {
        }

        public async Task CreateAsync(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public Task<List<Employee>> GetAllAsync()
        {
            return _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Employee entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public bool Exists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
