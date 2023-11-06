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
    public class BrandModels1Controller : ControllerBase
    {
        private readonly BTTH2Context _context;

        public BrandModels1Controller(BTTH2Context context)
        {
            _context = context;
        }

        // GET: api/BrandModels1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandModels>>> GetBrandModels()
        {
          if (_context.BrandModels == null)
          {
              return NotFound();
          }
            return await _context.BrandModels.ToListAsync();
        }

        // GET: api/BrandModels1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandModels>> GetBrandModels(int id)
        {
          if (_context.BrandModels == null)
          {
              return NotFound();
          }
            var brandModels = await _context.BrandModels.FindAsync(id);

            if (brandModels == null)
            {
                return NotFound();
            }

            return brandModels;
        }

        // PUT: api/BrandModels1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrandModels(int id, BrandModels brandModels)
        {
            if (id != brandModels.BrandId)
            {
                return BadRequest();
            }

            _context.Entry(brandModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandModelsExists(id))
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

        // POST: api/BrandModels1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BrandModels>> PostBrandModels(BrandModels brandModels)
        {
          if (_context.BrandModels == null)
          {
              return Problem("Entity set 'BTTH2Context.BrandModels'  is null.");
          }
            _context.BrandModels.Add(brandModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrandModels", new { id = brandModels.BrandId }, brandModels);
        }

        // DELETE: api/BrandModels1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrandModels(int id)
        {
            if (_context.BrandModels == null)
            {
                return NotFound();
            }
            var brandModels = await _context.BrandModels.FindAsync(id);
            if (brandModels == null)
            {
                return NotFound();
            }

            _context.BrandModels.Remove(brandModels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrandModelsExists(int id)
        {
            return (_context.BrandModels?.Any(e => e.BrandId == id)).GetValueOrDefault();
        }
    }
}
