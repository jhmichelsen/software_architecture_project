using Application;
using MassTransit;
using Messaging.Contract;

namespace Messaging;

public class WaterEventConsumer(IWaterService waterService) : IConsumer<WaterEvent>
{
    public async Task Consume(ConsumeContext<WaterEvent> context)
    {
        Console.WriteLine($"Water event consumed {context.Message.FactoryId} {context.Message.GreenHouseId} {context.Message.WaterOn}");
        await waterService.IsWaterOnAsync(context.Message.FactoryId, context.Message.GreenHouseId, context.Message.WaterOn);
    }
}