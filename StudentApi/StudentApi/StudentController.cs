using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentMvc.Models;

namespace StudentApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _context;

        public StudentController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudentModels()
        {
          if (_context.StudentModels == null)
          {
              return NotFound();
          }
            return await _context.StudentModels.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(string id)
        {
          if (_context.StudentModels == null)
          {
              return NotFound();
          }
            var studentModel = await _context.StudentModels.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentModel(string id, StudentModel studentModel)
        {
            if (id != studentModel.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
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

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudentModel(StudentModel studentModel)
        {
          if (_context.StudentModels == null)
          {
              return Problem("Entity set 'StudentDBContext.StudentModels'  is null.");
          }
            _context.StudentModels.Add(studentModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentModelExists(studentModel.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentModel", new { id = studentModel.StudentId }, studentModel);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentModel(string id)
        {
            if (_context.StudentModels == null)
            {
                return NotFound();
            }
            var studentModel = await _context.StudentModels.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            _context.StudentModels.Remove(studentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentModelExists(string id)
        {
            return (_context.StudentModels?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
