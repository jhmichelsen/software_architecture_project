using MassTransit;
using Messaging.Contract;
using SoilMoisture.Application;

namespace Messaging;

public class SoilMoistureEventConsumer(ISoilMoistureService soilMoistureService) : IConsumer<SoilMoistureEvent>
{
    public async Task Consume(ConsumeContext<SoilMoistureEvent> context)
    {
        Console.WriteLine($"Received message: {context.Message.FactoryId} {context.Message.GreenHouseId} {context.Message.SolMoisturePercentage}");
        await soilMoistureService.ProcessAsync();
    }
}