namespace Data.Waters;

public interface IWaterRepository
{
    Task AddWaterAsync(int factoryId, int greenhouseId, bool waterOn);
}