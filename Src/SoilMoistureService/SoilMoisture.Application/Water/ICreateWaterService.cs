namespace SoilMoisture.Application.Water;

public interface ICreateWaterService
{
    Task CreateWaterEventAsync(int factoryId, int greenhouseId, bool waterOn);
}