using Data;

namespace GreenhouseFactoryService.Seeder;

public static class DataSeeder
{
    public static void Seeder(AppDbContext context)
    {
        var factory = new FactoryEntity
        {
            Id = 1,
            Location = "Copenhagen",
            GreenHouseEntities = new List<GreenHouseEntity>()
            {
                new GreenHouseEntity()
                {
                    WaterOn = false
                },
                new GreenHouseEntity()
                {
                    WaterOn = false
                }
            }
        };
        
        var factory2 = new FactoryEntity
        {
            Id = 2,
            Location = "Odense",
            GreenHouseEntities = new List<GreenHouseEntity>()
            {
                new GreenHouseEntity()
                {
                    WaterOn = false
                },
                new GreenHouseEntity()
                {
                    WaterOn = false
                }
            }
        };

        context.AddRange(factory, factory2);
        context.SaveChanges();
    }
}