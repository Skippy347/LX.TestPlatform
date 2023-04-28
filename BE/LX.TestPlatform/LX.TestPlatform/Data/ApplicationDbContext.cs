using LX.TestPlatform.Entities;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPlatform.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
}