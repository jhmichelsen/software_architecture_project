namespace SoilMoisture.Application;

public interface ISoilMoistureService
{
    Task ProcessAsync(int factoryId, int greenhouseId, int solMoisturePercentage);
}