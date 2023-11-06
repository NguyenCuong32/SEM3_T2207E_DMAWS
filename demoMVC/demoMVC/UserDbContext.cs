using demoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace demoMVC;

public class UserDbContext : DbContext
{
    public  UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; }

}