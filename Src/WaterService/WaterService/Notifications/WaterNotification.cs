using Application.Interfaces;
using Microsoft.AspNetCore.SignalR;
using WaterService.Hubs;

namespace WaterService.Notifications;

public class WaterNotification(IHubContext<WaterHub> hubContext) : IWaterNotification
{
    public async Task IsWaterOnAsync(int factoryId, int greenhouseId, bool waterOn)
    {
        Console.WriteLine($"WaterNotification IsWaterOnAsync factoryId {factoryId} greenhouseId {greenhouseId} is water on {waterOn}");
        await hubContext.Clients.All.SendAsync(
            "WaterStatusChanged",
            new { factoryId, greenhouseId, waterOn }
        );
    }
}