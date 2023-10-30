using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Data;

public class BookStoreContext : IdentityDbContext<ApplicationUser>
{
    public BookStoreContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Book>? Books { get; set; }
    
}