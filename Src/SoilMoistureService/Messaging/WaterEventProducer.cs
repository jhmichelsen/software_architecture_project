using MassTransit;
using Messaging.Contract;
using SoilMoisture.Application;

namespace Messaging;

public class WaterEventProducer(IPublishEndpoint publisher) : IWaterEventProducer
{
    public async Task CreateWaterEventAsync(int factoryId, int greenhouseId, bool waterOn)
    {
        Console.WriteLine($"WaterEventProducer {factoryId} {greenhouseId} {waterOn}");
        await publisher.Publish(new WaterEvent
        {
            FactoryId = factoryId,
            GreenHouseId = greenhouseId,
            WaterOn = waterOn
        });
    }
}