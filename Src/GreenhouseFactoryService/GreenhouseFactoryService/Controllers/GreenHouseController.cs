using Microsoft.AspNetCore.Mvc;

namespace GreenhouseFactoryService.Controllers;

[ApiController]
[Route("green-house")]
public class GreenHouseController(ILogger<GreenHouseController> logger) : ControllerBase
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
    
    [HttpPut("update/{id}")]
    public IActionResult Update(int id)
    {
        return Ok();
    }
    
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}