using System;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI
{
	public class UserDbContext: DbContext
    {
		
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
    }
}

