using Azure_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Azure_MVC.Context
{
    
    public class BookDBContext : DbContext
    {
       
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookModel>().ToTable("Book");
        }
        public DbSet<BookModel> BookModels { get; set; }
        
    }
}
