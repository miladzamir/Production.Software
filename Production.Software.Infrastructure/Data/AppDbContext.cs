using Microsoft.EntityFrameworkCore;
using Production.Software.Core.Entities;

namespace Production.Software.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Product {get; set;}
}