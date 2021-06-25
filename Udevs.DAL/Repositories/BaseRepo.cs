using System;
using System.Collections.Generic;
using System.Text;
using WAD_WebApplication_7039.DAL;

namespace Udevs.DAL.Repositories
{
    public abstract class BaseRepo
    {
        protected readonly UdevsDbContext _context;

        protected BaseRepo(UdevsDbContext context)
        {
            _context = context;
        }
    }
}
