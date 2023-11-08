using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication001.Models;


namespace WebApplication001
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<UserModel> UserModels { get; set; }
    }
}