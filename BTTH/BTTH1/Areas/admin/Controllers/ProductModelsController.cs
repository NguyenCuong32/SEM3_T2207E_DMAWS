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
    public class ProductModelsController : Controller
    {
        private readonly BTTH1Context _context;

        public ProductModelsController(BTTH1Context context)
        {
            _context = context;
        }

        // GET: admin/ProductModels
        public async Task<IActionResult> Index()
        {
            var bTTH1Context = _context.ProductModels.Include(p => p.Brand).Include(p => p.Category);
            return View(await bTTH1Context.ToListAsync());
        }

        // GET: admin/ProductModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductModels == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productModels == null)
            {
                return NotFound();
            }

            return View(productModels);
        }

        // GET: admin/ProductModels/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.BrandModels, "BrandId", "BrandDesc");
            ViewData["CateId"] = new SelectList(_context.CategoryModels, "CateId", "CateDesc");
            return View();
        }

        // POST: admin/ProductModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescription,ProductPrice,ProductQuantity,ProductImg,CateId,BrandId")] ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.BrandModels, "BrandId", "BrandDesc", productModels.BrandId);
            ViewData["CateId"] = new SelectList(_context.CategoryModels, "CateId", "CateDesc", productModels.CateId);
            return View(productModels);
        }

        // GET: admin/ProductModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductModels == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels.FindAsync(id);
            if (productModels == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.BrandModels, "BrandId", "BrandDesc", productModels.BrandId);
            ViewData["CateId"] = new SelectList(_context.CategoryModels, "CateId", "CateDesc", productModels.CateId);
            return View(productModels);
        }

        // POST: admin/ProductModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,ProductPrice,ProductQuantity,ProductImg,CateId,BrandId")] ProductModels productModels)
        {
            if (id != productModels.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelsExists(productModels.ProductId))
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
            ViewData["BrandId"] = new SelectList(_context.BrandModels, "BrandId", "BrandDesc", productModels.BrandId);
            ViewData["CateId"] = new SelectList(_context.CategoryModels, "CateId", "CateDesc", productModels.CateId);
            return View(productModels);
        }

        // GET: admin/ProductModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductModels == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productModels == null)
            {
                return NotFound();
            }

            return View(productModels);
        }

        // POST: admin/ProductModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductModels == null)
            {
                return Problem("Entity set 'BTTH1Context.ProductModels'  is null.");
            }
            var productModels = await _context.ProductModels.FindAsync(id);
            if (productModels != null)
            {
                _context.ProductModels.Remove(productModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelsExists(int id)
        {
          return (_context.ProductModels?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
