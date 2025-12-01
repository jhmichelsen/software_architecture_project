namespace SoilMoisture.Application;

public interface IWaterEventProducer
{
    Task CreateWaterEventAsync(int factoryId, int greenhouseId, bool waterOn);
}