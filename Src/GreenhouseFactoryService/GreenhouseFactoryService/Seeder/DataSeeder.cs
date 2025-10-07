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
                },
                new GreenHouseEntity()
                {
                }
            }
        };

        context.AddRange(factory);
        context.SaveChanges();
    }
}