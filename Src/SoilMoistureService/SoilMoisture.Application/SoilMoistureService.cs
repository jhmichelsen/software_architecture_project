namespace SoilMoisture.Application;

public class SoilMoistureService : ISoilMoistureService
{
    public Task ProcessAsync()
    {
        Console.WriteLine("Processing SoilMoisture Service");
        return Task.CompletedTask;
    }
}