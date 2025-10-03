using Microsoft.AspNetCore.Mvc;

namespace SimulatorUI.Controllers;

[ApiController]
[Route("greenhouse-simulator/simulate")]
public class GreenHouseSimulatorController(ILogger<GreenHouseSimulatorController> logger) : ControllerBase
{
    private readonly ILogger<GreenHouseSimulatorController> _logger = logger;

    [HttpPost("factory/{factoryId}/green-house/{greenhouseId}/soil-moisture/{percentage}")]
    public IActionResult TriggerSoilMoisture(int factoryId, int greenhouseId, int percentage)
    {
        return Ok();
    }
}