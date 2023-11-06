using Microsoft.EntityFrameworkCore;
using PhamNgocDung.Models;

namespace PhamNgocDung.DAL
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext()
        {

        }
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {
        }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeModel>().ToTable("Employee_Tbl");
            modelBuilder.Entity<DepartmentModel>().ToTable("Department_Tbl")
                .HasMany(department => department.Employees)
                .WithOne(employee => employee.Department)
                .HasForeignKey(employee => employee.departmentId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "Server=tcp:phamngocdung.database.windows.net,1433;Initial Catalog=DBTest;Persist Security Info=False;User ID=phamngocdung;Password=Hoilamgi#2010;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
}
