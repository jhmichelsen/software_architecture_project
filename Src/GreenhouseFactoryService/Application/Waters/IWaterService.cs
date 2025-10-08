namespace Application.Waters;

public interface IWaterService
{
    Task AddWaterAsync(int factoryId, int greenhouseId, bool waterOn);
}