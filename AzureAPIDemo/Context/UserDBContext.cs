using AzureAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureAPIDemo.Context
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext>options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().ToTable("User");
        }
        DbSet<UserModel> UserModels;
        public DbSet<AzureAPIDemo.Models.UserModel> UserModel { get; set; } = default!;
    }
}
