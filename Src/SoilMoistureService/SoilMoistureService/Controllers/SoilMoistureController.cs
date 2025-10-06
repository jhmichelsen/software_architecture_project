using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace SoilMoistureService.Controllers;

[ApiController]
[Route("soil-moisture-test")]
public class SoilMoistureController(ILogger<SoilMoistureController> logger, IPublishEndpoint publishEndpoint) : ControllerBase
{
    [HttpPost("factory/{factoryId}/green-house/{greenhouseId}/soil-moisture/{percentage}")]
    public async Task<IActionResult> TriggerSoilMoistureTestEvent(int factoryId, int greenhouseId, int percentage)
    {
        /*await publishEndpoint.Publish(new SoilMoistureEvent
        {
            FactoryId = factoryId,
            GreenHouseId = greenhouseId,
            SolMoisturePercentage = percentage
        });*/
        return Ok();
    }
}