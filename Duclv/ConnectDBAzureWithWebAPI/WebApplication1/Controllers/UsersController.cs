using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.modal;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TestDatabaseContext _context;

        public UsersController(TestDatabaseContext context)
        {
            _context = context;
        }

        [Route("api/v1/GetUser")]
        [HttpGet]
        public IActionResult Get()
        {
            List<users> list = _context.users.ToList();
            return Ok(list);
        }


        [Route("api/v1/AddUser")]
        [HttpPost]
        public IActionResult Add(users user)
        {
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
                return Ok("Tạo thành công.");
            }
            catch (Exception ex)
            {

                return BadRequest("Tạo không thành công.");
            }
           
        }


        [Route("api/v1/delete/{id}")]
        [HttpDelete]
        public IActionResult delete(int id)
        {
            try
            {
                users user =  _context.users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    _context.users.Remove(user);
                    _context.SaveChanges();
                    return Ok("Xóa thành công.");
                }
                else
                {
                    return BadRequest("User không tồn tại.");
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest("Tạo không thành công.");
            }

        }

    }
}
