using Domain;
using SoilMoisture.Application.Water;

namespace SoilMoisture.Application.SoilMoisture;

public class SoilMoistureService(ICreateWaterService createWaterService) : ISoilMoistureService
{
    public async Task ProcessAsync(Factory factory)
    {
        Console.WriteLine("Processing GetGetSoilMoistureService");
        foreach (var greenhouse in factory.Greenhouses)
        {
            if (greenhouse.SolMoisturePercentage < 50)
            {
                await createWaterService.CreateWaterEventAsync(factory.Id, greenhouse.Id, true);
            }

            if (greenhouse.SolMoisturePercentage > 80)
            {
                await createWaterService.CreateWaterEventAsync(factory.Id, greenhouse.Id, false);
            }
        }
    }
}