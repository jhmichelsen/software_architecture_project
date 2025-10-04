using Application.SoilMoisture;
using MassTransit;

namespace Messaging.SoilMoistureEvents;

public class SoilMoistureEventConsumer(ISoilMoistureService moistureService) : IConsumer<SoilMoistureEvent>
{
    public async Task Consume(ConsumeContext<SoilMoistureEvent> context)
    {
        Console.WriteLine($"Received message: {context.Message.FactoryId} {context.Message.GreenHouseId} {context.Message.SolMoisturePercentage}");
        await moistureService.ProcessAsync();
    }
}