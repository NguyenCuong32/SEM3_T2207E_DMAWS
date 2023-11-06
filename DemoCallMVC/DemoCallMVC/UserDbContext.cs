using System;
using DemoCallMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCallMVC
{
	public class UserDbContext: DbContext
	{
		public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
		{
		}
		public DbSet<UserModel> Users { get; set; }
	}
}

