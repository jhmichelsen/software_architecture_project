namespace SoilMoisture.Application;

public interface IWaterEventService
{
    Task CreateWaterEventAsync(int factoryId, int greenhouseId, bool waterOn);
}