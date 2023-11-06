using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTTH2.Models;

namespace BTTH2.Data
{
    public class BTTH2Context : DbContext
    {
        public BTTH2Context (DbContextOptions<BTTH2Context> options)
            : base(options)
        {
			

		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<User>().ToTable("User_Tbl");//Employee_Tbl là tên bảng bên SQL Server
			modelBuilder.Entity<CategoryModels>().ToTable("Cate_Tbl");
			modelBuilder.Entity<ProductModels>().ToTable("Product_Tbl");
			modelBuilder.Entity<BrandModels>().ToTable("Brand_Tbl");

		}

		public DbSet<BTTH2.Models.User> User { get; set; } = default!;

        public DbSet<BTTH2.Models.BrandModels> BrandModels { get; set; } = default!;

        public DbSet<BTTH2.Models.ProductModels> ProductModels { get; set; } = default!;

        public DbSet<BTTH2.Models.CategoryModels> CategoryModels { get; set; } = default!;
    }
}
