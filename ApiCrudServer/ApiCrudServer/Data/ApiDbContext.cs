using Microsoft.EntityFrameworkCore;

namespace ApiCrudServer.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customers");

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
