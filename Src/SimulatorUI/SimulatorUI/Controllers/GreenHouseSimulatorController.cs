using MassTransit;
using Messaging.Contract;
using Microsoft.AspNetCore.Mvc;

namespace SimulatorUI.Controllers;

[ApiController]
[Route("greenhouse-simulator/simulate")]
public class GreenHouseSimulatorController(ILogger<GreenHouseSimulatorController> logger, IPublishEndpoint publishEndpoint) : ControllerBase
{
    [HttpPost("factory/{factoryId}/green-house/{greenhouseId}/soil-moisture/{percentage}")]
    public async Task<IActionResult> TriggerSoilMoisture(int factoryId, int greenhouseId, int percentage)
    {
        Console.WriteLine($"Triggering soil-moisture {factoryId}-{greenhouseId}-{percentage}");
        await publishEndpoint.Publish(new SoilMoistureEvent
        {
            FactoryId = factoryId,
            GreenHouseId = greenhouseId,
            SolMoisturePercentage = percentage
        });
        return Ok();
    }
    
    [HttpPost("factory/{factoryId}/green-house/{greenhouseId}/soil-moisture/{percentage}/performance-testing")]
    public async Task<IActionResult> BulkSoilMoisture(
        int factoryId, int greenhouseId, int  percentage,
        [FromQuery] int count = 10000)
    {
        Console.WriteLine($"Starting bulk publish of {count} soil moisture events...");

        var sw = System.Diagnostics.Stopwatch.StartNew();

        // Limit concurrency to avoid overwhelming RabbitMQ
        var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 100 };

        await Parallel.ForEachAsync(Enumerable.Range(0, count), parallelOptions, async (i, cancellationToken) =>
        {
            await publishEndpoint.Publish(new SoilMoistureEvent
            {
                FactoryId = factoryId,
                GreenHouseId = greenhouseId,
                SolMoisturePercentage = percentage
            }, cancellationToken);
        });

        sw.Stop();

        Console.WriteLine($"Published {count} events in {sw.Elapsed.Seconds} ms");

        return Ok(new
        {
            Count = count,
            DurationMs = sw.Elapsed.Seconds
        });
    }
}