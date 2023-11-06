using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTTH1.Models;
using BTTH1.Areas.login;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BTTH1.Data
{
    public class BTTH1Context : IdentityDbContext<AppUser>
	{
        public BTTH1Context (DbContextOptions<BTTH1Context> options)
            : base(options)
        {
        }

        public DbSet<BTTH1.Models.User> User { get; set; } = default!;

        public DbSet<BTTH1.Models.BrandModels> BrandModels { get; set; } = default!;

        public DbSet<BTTH1.Models.CategoryModels> CategoryModels { get; set; } = default!;

        public DbSet<BTTH1.Models.ProductModels> ProductModels { get; set; } = default!;
    }
}
