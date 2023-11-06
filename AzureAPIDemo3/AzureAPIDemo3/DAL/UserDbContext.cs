using AzureAPIDemo3.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureAPIDemo3.DAL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().ToTable("User");
        }*/
        public DbSet<UserModel> Users { get; set; }
    }
}
