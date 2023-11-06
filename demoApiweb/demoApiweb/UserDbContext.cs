using demoApiweb.Models;
using Microsoft.EntityFrameworkCore;

namespace demoApiweb;

public class UserDbContext : DbContext
{
    public  UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; }

}