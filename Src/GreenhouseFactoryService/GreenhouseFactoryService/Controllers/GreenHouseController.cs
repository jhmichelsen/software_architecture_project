using Application.Waters;
using Microsoft.AspNetCore.Mvc;

namespace GreenhouseFactoryService.Controllers;

[ApiController]
[Route("green-house")]
public class GreenHouseController(ILogger<GreenHouseController> logger, IWaterService waterService) : ControllerBase
{
    [HttpGet("all")]
    public IActionResult All()
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok();
    }
    
    [HttpPost("create/{name}")]
    public IActionResult Create(string name)
    {
        return Ok();
    }
    
    [HttpPut("factory/{factoryId}/greenhouse/{greenhouseId}/water-on/{waterOn}/update")]
    public IActionResult Update(int factoryId, int greenhouseId, bool waterOn)
    {
        waterService.AddWaterAsync(factoryId, greenhouseId, waterOn);
        return Ok();
    }
    
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}