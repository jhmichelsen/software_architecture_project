namespace SoilMoisture.Application;

public class SoilMoistureService(IWaterEventService waterEventService) : ISoilMoistureService
{
    public async Task ProcessAsync(int factoryId, int greenhouseId, int solMoisturePercentage)
    {
        Console.WriteLine("Processing SoilMoisture Service");
        if (true)
        {
            await waterEventService.CreateWaterEventAsync(factoryId, greenhouseId, true);
        }
    }
}