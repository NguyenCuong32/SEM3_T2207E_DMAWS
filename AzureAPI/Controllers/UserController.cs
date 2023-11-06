using AzureTest.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(UserDbContext userDbContext) 
        {
            UserDbContext = userDbContext;
        }
        public UserDbContext UserDbContext { get; set; }

        [HttpGet(Name = "DungGetUsers")]
        public List<UserModel>DungGetUsers()
        { 
            return UserDbContext.Users.ToList();
        }

        [HttpPost(Name = "DungAddUser")]
        public IActionResult DungAddUser([FromBody] UserModel newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Invalid data");
            }

            UserDbContext.Users.Add(newUser);
            UserDbContext.SaveChanges();

            
            return CreatedAtRoute("DungGetUsers", new { id = newUser.Id }, newUser);
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
