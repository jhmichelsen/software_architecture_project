namespace Application.Interfaces;

public interface IWaterNotification
{
    Task IsWaterOnAsync(int factoryId, int greenhouseId, bool waterOn);
}