namespace Application;

public interface IWaterService
{
    Task IsWaterOnAsync(int factoryId, int greenhouseId, bool turnOnWater);
}