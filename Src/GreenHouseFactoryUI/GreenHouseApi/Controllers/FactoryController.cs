using Microsoft.AspNetCore.Mvc;

namespace GreenHouseApi.Controllers;

public class FactoryController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}