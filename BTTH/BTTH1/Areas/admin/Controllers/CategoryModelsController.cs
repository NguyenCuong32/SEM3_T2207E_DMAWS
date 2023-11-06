﻿using System;
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
    public class CategoryModelsController : Controller
    {
        private readonly BTTH1Context _context;

        public CategoryModelsController(BTTH1Context context)
        {
            _context = context;
        }

        // GET: admin/CategoryModels
        public async Task<IActionResult> Index()
        {
              return _context.CategoryModels != null ? 
                          View(await _context.CategoryModels.ToListAsync()) :
                          Problem("Entity set 'BTTH1Context.CategoryModels'  is null.");
        }

        // GET: admin/CategoryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoryModels == null)
            {
                return NotFound();
            }

            var categoryModels = await _context.CategoryModels
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (categoryModels == null)
            {
                return NotFound();
            }

            return View(categoryModels);
        }

        // GET: admin/CategoryModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/CategoryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CateId,CateName,CateDesc,CateOrder")] CategoryModels categoryModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryModels);
        }

        // GET: admin/CategoryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoryModels == null)
            {
                return NotFound();
            }

            var categoryModels = await _context.CategoryModels.FindAsync(id);
            if (categoryModels == null)
            {
                return NotFound();
            }
            return View(categoryModels);
        }

        // POST: admin/CategoryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CateId,CateName,CateDesc,CateOrder")] CategoryModels categoryModels)
        {
            if (id != categoryModels.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelsExists(categoryModels.CateId))
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
            return View(categoryModels);
        }

        // GET: admin/CategoryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoryModels == null)
            {
                return NotFound();
            }

            var categoryModels = await _context.CategoryModels
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (categoryModels == null)
            {
                return NotFound();
            }

            return View(categoryModels);
        }

        // POST: admin/CategoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoryModels == null)
            {
                return Problem("Entity set 'BTTH1Context.CategoryModels'  is null.");
            }
            var categoryModels = await _context.CategoryModels.FindAsync(id);
            if (categoryModels != null)
            {
                _context.CategoryModels.Remove(categoryModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryModelsExists(int id)
        {
          return (_context.CategoryModels?.Any(e => e.CateId == id)).GetValueOrDefault();
        }
    }
}