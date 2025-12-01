namespace SoilMoisture.Application.Water;

public class CreateCreateWaterService(IWaterEventProducer waterEventProducer) : ICreateWaterService
{
   public async Task CreateWaterEventAsync(int factoryId, int greenhouseId, bool waterOn)
   {
      await  waterEventProducer.CreateWaterEventAsync(factoryId, greenhouseId, waterOn);
   }
}