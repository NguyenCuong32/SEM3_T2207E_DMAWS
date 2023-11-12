using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
              return _context.StudentModels != null ? 
                          View(await _context.StudentModels.ToListAsync()) :
                          Problem("Entity set 'StudentDbContext.StudentModels'  is null.");
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.StudentModels == null)
            {
                return NotFound();
            }

            var studentModels = await _context.StudentModels
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentModels == null)
            {
                return NotFound();
            }

            return View(studentModels);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,Birthday,Address")] StudentModels studentModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentModels);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.StudentModels == null)
            {
                return NotFound();
            }

            var studentModels = await _context.StudentModels.FindAsync(id);
            if (studentModels == null)
            {
                return NotFound();
            }
            return View(studentModels);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName,Birthday,Address")] StudentModels studentModels)
        {
            if (id != studentModels.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentModelsExists(studentModels.StudentID))
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
            return View(studentModels);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.StudentModels == null)
            {
                return NotFound();
            }

            var studentModels = await _context.StudentModels
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentModels == null)
            {
                return NotFound();
            }

            return View(studentModels);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.StudentModels == null)
            {
                return Problem("Entity set 'StudentDbContext.StudentModels'  is null.");
            }
            var studentModels = await _context.StudentModels.FindAsync(id);
            if (studentModels != null)
            {
                _context.StudentModels.Remove(studentModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentModelsExists(string id)
        {
          return (_context.StudentModels?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
