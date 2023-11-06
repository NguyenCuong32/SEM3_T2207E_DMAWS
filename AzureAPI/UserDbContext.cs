using AzureTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureTest
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().HasKey(x => x.Id);
            modelBuilder.Entity<UserModel>().Property(p => p.Id)
                                            .ValueGeneratedOnAdd()
                                            .HasDefaultValue(1);
            modelBuilder.Entity<UserModel>().ToTable("Users");
        }
        public DbSet<UserModel> Users { get; set;}
    }
}
