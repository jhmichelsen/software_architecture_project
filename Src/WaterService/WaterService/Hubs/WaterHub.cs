using Microsoft.AspNetCore.SignalR;

namespace WaterService.Hubs;

public class WaterHub : Hub
{
    public async Task NotifyWaterOn(int factoryId, int greenhouseId, bool waterOn)
    {
        Console.WriteLine($"WaterStatusChanged for factoryId: {factoryId}, greenhouseId: {greenhouseId}, turnOnWater {waterOn}");
        await Clients.All.SendAsync("WaterStatusChanged", new { factoryId, greenhouseId, turnOnWater = waterOn });
    }
}