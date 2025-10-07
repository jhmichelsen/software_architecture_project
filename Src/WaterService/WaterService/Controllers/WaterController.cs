using Application;
using Microsoft.AspNetCore.Mvc;

namespace WaterService.Controllers;

[ApiController]
[Route("water")]
public class WaterController(IWaterService waterService) : ControllerBase
{
    [HttpPost("factory/{factoryId}/green-house/{greenhouseId}/is-water-on/{isWaterOn}")]
    public async Task<IActionResult> TriggerWater(int factoryId, int greenhouseId, bool isWaterOn)
    {
        await waterService.IsWaterOnAsync(factoryId, greenhouseId, isWaterOn);
        return Ok();
    }
}