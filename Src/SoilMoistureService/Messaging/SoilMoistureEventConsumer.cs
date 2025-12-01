using Domain;
using MassTransit;
using Messaging.Contract;
using SoilMoisture.Application;
using SoilMoisture.Application.SoilMoisture;

namespace Messaging;

public class SoilMoistureEventConsumer(ISoilMoistureService soilMoistureService) : IConsumer<SoilMoistureEvent>
{
    public async Task Consume(ConsumeContext<SoilMoistureEvent> context)
    {
        Console.WriteLine($"Received message: {context.Message.FactoryId} {context.Message.GreenHouseId} {context.Message.SolMoisturePercentage}");
        await soilMoistureService.ProcessAsync(
            new Factory
            {
                Id = context.Message.FactoryId,
                Greenhouses =
                [
                    new Greenhouse
                    {
                        Id = context.Message.GreenHouseId,
                        SolMoisturePercentage = context.Message.SolMoisturePercentage
                    }
                ]
            });
    }
}