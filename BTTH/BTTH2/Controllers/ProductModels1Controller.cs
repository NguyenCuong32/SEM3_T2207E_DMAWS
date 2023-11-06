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
    public class ProductModels1Controller : ControllerBase
    {
        private readonly BTTH2Context _context;

        public ProductModels1Controller(BTTH2Context context)
        {
            _context = context;
        }

        // GET: api/ProductModels1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModels>>> GetProductModels()
        {
          if (_context.ProductModels == null)
          {
              return NotFound();
          }
            return await _context.ProductModels.ToListAsync();
        }

        // GET: api/ProductModels1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModels>> GetProductModels(int id)
        {
          if (_context.ProductModels == null)
          {
              return NotFound();
          }
            var productModels = await _context.ProductModels.FindAsync(id);

            if (productModels == null)
            {
                return NotFound();
            }

            return productModels;
        }

        // PUT: api/ProductModels1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModels(int id, ProductModels productModels)
        {
            if (id != productModels.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelsExists(id))
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

        // POST: api/ProductModels1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductModels>> PostProductModels(ProductModels productModels)
        {
          if (_context.ProductModels == null)
          {
              return Problem("Entity set 'BTTH2Context.ProductModels'  is null.");
          }
            _context.ProductModels.Add(productModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductModels", new { id = productModels.ProductId }, productModels);
        }

        // DELETE: api/ProductModels1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModels(int id)
        {
            if (_context.ProductModels == null)
            {
                return NotFound();
            }
            var productModels = await _context.ProductModels.FindAsync(id);
            if (productModels == null)
            {
                return NotFound();
            }

            _context.ProductModels.Remove(productModels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductModelsExists(int id)
        {
            return (_context.ProductModels?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
