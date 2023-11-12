using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

using Microsoft.Extensions.Options;

namespace ProductManagement
{
    public class StudentDbContext:DbContext
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public StudentDbContext():base()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        {
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        {
        }
        public DbSet<StudentDbContext> Students;

        public object StudentModel { get; internal set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=localhost,1433;Database=StudentManagers;User Id=sa;Password=11;TrustServerCertificate=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentModels>().ToTable("Students");
            
        }
        public DbSet<ProductManagement.Models.StudentModels> StudentModels { get; set; } = default!;


    }
}
