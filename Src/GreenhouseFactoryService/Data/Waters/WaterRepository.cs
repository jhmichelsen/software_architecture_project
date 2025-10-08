using Microsoft.EntityFrameworkCore;

namespace Data.Waters;

public class WaterRepository(AppDbContext context) : IWaterRepository 
{
    public async Task AddWaterAsync(int factoryId, int greenhouseId, bool waterOn)
    {
        
        var factory = await context.Factories.FirstOrDefaultAsync(f => f.Id == factoryId);
        if (factory != null)
        {
            var greenhouse =  await context.GreenHouses.FirstOrDefaultAsync(g => g.Id == greenhouseId);
            if (greenhouse != null)
            {
                greenhouse.WaterOn = waterOn;
                await context.SaveChangesAsync();
                Console.WriteLine($"Water changed for factoryId {factoryId} greenhouseId {greenhouseId} waterOn {waterOn}");
            }
        }
    }
}