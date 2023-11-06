using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamNgocDung.DAL;
using PhamNgocDung.Models;

namespace PhamNgocDung.Controllers
{
    public class EmployeeModelsController : Controller
    {
        private readonly ExamDbContext _context;

        public EmployeeModelsController(ExamDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeModels
        public async Task<IActionResult> Index()
        {
            var examDbContext = _context.Employees.Include(e => e.Department);
            return View(await examDbContext.ToListAsync());
        }

        // GET: EmployeeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.employeeId == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // GET: EmployeeModels/Create
        public IActionResult Create()
        {
            ViewData["departmentId"] = new SelectList(_context.Departments, "departmentId", "departmentId");
            return View();
        }

        // POST: EmployeeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("employeeId,departmentId,employeeName,employeeCode,employeeDepartment,employeeRank,employeeEmail,employeePassword")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["departmentId"] = new SelectList(_context.Departments, "departmentId", "departmentId", employeeModel.departmentId);
            return View(employeeModel);
        }

        // GET: EmployeeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }
            ViewData["departmentId"] = new SelectList(_context.Departments, "departmentId", "departmentId", employeeModel.departmentId);
            return View(employeeModel);
        }

        // POST: EmployeeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("employeeId,departmentId,employeeName,employeeCode,employeeDepartment,employeeRank,employeeEmail,employeePassword")] EmployeeModel employeeModel)
        {
            if (id != employeeModel.employeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeModelExists(employeeModel.employeeId))
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
            ViewData["departmentId"] = new SelectList(_context.Departments, "departmentId", "departmentId", employeeModel.departmentId);
            return View(employeeModel);
        }

        // GET: EmployeeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.employeeId == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // POST: EmployeeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ExamDbContext.Employees'  is null.");
            }
            var employeeModel = await _context.Employees.FindAsync(id);
            if (employeeModel != null)
            {
                _context.Employees.Remove(employeeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeModelExists(int id)
        {
          return (_context.Employees?.Any(e => e.employeeId == id)).GetValueOrDefault();
        }
    }
}
