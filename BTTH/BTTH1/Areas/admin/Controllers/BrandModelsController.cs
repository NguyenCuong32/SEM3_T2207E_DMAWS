using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTTH1.Data;
using BTTH1.Models;

namespace BTTH1.Areas.admin.Controllers
{
    [Area("admin")]
    public class BrandModelsController : Controller
    {
        private readonly BTTH1Context _context;

        public BrandModelsController(BTTH1Context context)
        {
            _context = context;
        }

        // GET: admin/BrandModels
        public async Task<IActionResult> Index()
        {
              return _context.BrandModels != null ? 
                          View(await _context.BrandModels.ToListAsync()) :
                          Problem("Entity set 'BTTH1Context.BrandModels'  is null.");
        }

        // GET: admin/BrandModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BrandModels == null)
            {
                return NotFound();
            }

            var brandModels = await _context.BrandModels
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brandModels == null)
            {
                return NotFound();
            }

            return View(brandModels);
        }

        // GET: admin/BrandModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/BrandModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,BrandName,BrandDesc,BrandOrder")] BrandModels brandModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brandModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandModels);
        }

        // GET: admin/BrandModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BrandModels == null)
            {
                return NotFound();
            }

            var brandModels = await _context.BrandModels.FindAsync(id);
            if (brandModels == null)
            {
                return NotFound();
            }
            return View(brandModels);
        }

        // POST: admin/BrandModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,BrandName,BrandDesc,BrandOrder")] BrandModels brandModels)
        {
            if (id != brandModels.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brandModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandModelsExists(brandModels.BrandId))
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
            return View(brandModels);
        }

        // GET: admin/BrandModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BrandModels == null)
            {
                return NotFound();
            }

            var brandModels = await _context.BrandModels
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brandModels == null)
            {
                return NotFound();
            }

            return View(brandModels);
        }

        // POST: admin/BrandModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BrandModels == null)
            {
                return Problem("Entity set 'BTTH1Context.BrandModels'  is null.");
            }
            var brandModels = await _context.BrandModels.FindAsync(id);
            if (brandModels != null)
            {
                _context.BrandModels.Remove(brandModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandModelsExists(int id)
        {
          return (_context.BrandModels?.Any(e => e.BrandId == id)).GetValueOrDefault();
        }
    }
}
