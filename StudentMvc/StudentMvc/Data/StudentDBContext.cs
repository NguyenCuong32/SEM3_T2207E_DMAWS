using System;
using Microsoft.EntityFrameworkCore;
using StudentMvc.Models;

namespace StudentMvc.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<StudentModel> StudentModels { get; set; }

    }
}
