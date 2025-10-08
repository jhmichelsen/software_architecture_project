using Application.Interfaces;

namespace Application;

public class WaterService(IWaterNotification waterNotification) : IWaterService
{
    public async Task IsWaterOnAsync(int factoryId, int greenhouseId, bool turnOnWater)
    {
        Console.WriteLine("WaterService IsWaterOnAsync processing");
        await waterNotification.IsWaterOnAsync(factoryId, greenhouseId, turnOnWater);
    }
}