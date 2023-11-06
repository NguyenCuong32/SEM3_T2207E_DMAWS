using Microsoft.EntityFrameworkCore;

namespace WebApplication1.modal
{
    public class TestDatabaseContext : DbContext
    {
        public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options) : base(options)
        {

        }
        public DbSet<users> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
