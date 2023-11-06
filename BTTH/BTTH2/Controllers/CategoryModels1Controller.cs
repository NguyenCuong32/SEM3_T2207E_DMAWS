using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTTH2.Data;
using BTTH2.Models;

namespace BTTH2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryModels1Controller : ControllerBase
    {
        private readonly BTTH2Context _context;

        public CategoryModels1Controller(BTTH2Context context)
        {
            _context = context;
        }

        // GET: api/CategoryModels1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModels>>> GetCategoryModels()
        {
          if (_context.CategoryModels == null)
          {
              return NotFound();
          }
            return await _context.CategoryModels.ToListAsync();
        }

        // GET: api/CategoryModels1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModels>> GetCategoryModels(int id)
        {
          if (_context.CategoryModels == null)
          {
              return NotFound();
          }
            var categoryModels = await _context.CategoryModels.FindAsync(id);

            if (categoryModels == null)
            {
                return NotFound();
            }

            return categoryModels;
        }

        // PUT: api/CategoryModels1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryModels(int id, CategoryModels categoryModels)
        {
            if (id != categoryModels.CateId)
            {
                return BadRequest();
            }

            _context.Entry(categoryModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CategoryModels1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryModels>> PostCategoryModels(CategoryModels categoryModels)
        {
          if (_context.CategoryModels == null)
          {
              return Problem("Entity set 'BTTH2Context.CategoryModels'  is null.");
          }
            _context.CategoryModels.Add(categoryModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryModels", new { id = categoryModels.CateId }, categoryModels);
        }

        // DELETE: api/CategoryModels1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryModels(int id)
        {
            if (_context.CategoryModels == null)
            {
                return NotFound();
            }
            var categoryModels = await _context.CategoryModels.FindAsync(id);
            if (categoryModels == null)
            {
                return NotFound();
            }

            _context.CategoryModels.Remove(categoryModels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryModelsExists(int id)
        {
            return (_context.CategoryModels?.Any(e => e.CateId == id)).GetValueOrDefault();
        }
    }
}
