using Microsoft.EntityFrameworkCore;
using Project.Model;

namespace WebApplication1
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> UserModels { get; set; }
    }
}