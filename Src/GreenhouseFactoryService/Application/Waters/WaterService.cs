using Data.Waters;

namespace Application.Waters;

public class WaterService(IWaterRepository waterRepository) : IWaterService
{
    public Task AddWaterAsync(int factoryId, int greenhouseId, bool waterOn)
    {
        return waterRepository.AddWaterAsync(factoryId, greenhouseId, waterOn);
    }
}