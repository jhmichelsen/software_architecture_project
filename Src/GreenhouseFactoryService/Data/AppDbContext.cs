using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<FactoryEntity> Factories { get; set; } 
    public DbSet<GreenHouseEntity> GreenHouses { get; set; } 
}