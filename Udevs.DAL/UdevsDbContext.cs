using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_WebApplication_7039.DAL.DBO;

namespace WAD_WebApplication_7039.DAL
{
    public class UdevsDbContext : DbContext
    {
        public UdevsDbContext(DbContextOptions<UdevsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
