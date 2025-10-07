using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenhouseFactoryService.Controllers;

[ApiController]
[Route("factory")]
public class FactoryController(ILogger<FactoryController> logger, AppDbContext context) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> All()
    {
        var factories = await context.Factories
            .Include(f => f.GreenHouseEntities)
            .ToListAsync();
        
        return Ok(factories);
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