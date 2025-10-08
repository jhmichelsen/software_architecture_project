using Application.Waters;
using MassTransit;
using Messaging.Contract;

namespace Messaging;

public class WaterEventConsumer(IWaterService waterService) : IConsumer<WaterEvent>
{
    public async Task Consume(ConsumeContext<WaterEvent> context)
    {
        Console.WriteLine($"WaterEventConsumer Received message: {context.Message.FactoryId} {context.Message.GreenHouseId} {context.Message.WaterOn}");
        await waterService.AddWaterAsync(context.Message.FactoryId, context.Message.GreenHouseId, context.Message.WaterOn);
    }
}