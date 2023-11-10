using Microsoft.EntityFrameworkCore;
using MVC_Azure02.Models;

namespace MVC_Azure02.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Student");

        }
        DbSet<Student> Students;
        public DbSet<MVC_Azure02.Models.Student> Student { get; set; } = default!;
    }
}
