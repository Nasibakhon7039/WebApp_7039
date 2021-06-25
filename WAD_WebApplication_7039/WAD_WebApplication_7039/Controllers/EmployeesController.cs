using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Udevs.DAL.Repositories;
using WAD_WebApplication_7039.DAL;
using WAD_WebApplication_7039.DAL.DBO;
using WAD_WebApplication_7039.Models;

namespace WAD_WebApplication_7039.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IRepository<Department> _departmentRepo;

        public EmployeesController(IRepository<Employee> employeeRepo, IRepository<Department> departmentRepo)
        {
            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _employeeRepo.GetAllAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,DepartmentId,JobPosition,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepo.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetAllAsync(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetAllAsync(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,DepartmentId,JobPosition,Salary")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepo.UpdateAsync(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_employeeRepo.Exists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetAllAsync(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
