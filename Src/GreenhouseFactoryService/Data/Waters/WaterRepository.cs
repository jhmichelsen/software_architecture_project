using Microsoft.EntityFrameworkCore;
using Polly;

namespace Data.Waters;

public class WaterRepository(IDbContextFactory<AppDbContext> contextFactory, IAsyncPolicy retryPolicy) : IWaterRepository 
{
    public async Task AddWaterAsync(int factoryId, int greenhouseId, bool waterOn)
    {
        await retryPolicy.ExecuteAsync(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var factory = await context.Factories.FirstOrDefaultAsync(f => f.Id == factoryId);
            if (factory == null)
            {
                Console.WriteLine($"Factory not found {factoryId}");
                return;
            }
    
            var greenhouse =  await context.GreenHouses.FirstOrDefaultAsync(g => g.Id == greenhouseId);
            if (greenhouse == null)
            {
                Console.WriteLine($"Greenhouse not found {greenhouseId}");
                return;
            }
    
            greenhouse.WaterOn = waterOn;
            await context.SaveChangesAsync();
    
            Console.WriteLine($"Water status changed for factoryId {factoryId} greenhouseId {greenhouseId} waterOn {waterOn}");
        });
    }
}