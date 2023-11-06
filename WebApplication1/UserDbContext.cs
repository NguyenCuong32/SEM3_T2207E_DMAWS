using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<UserModel> UserModels { get; set; }
    }
}




