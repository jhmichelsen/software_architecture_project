using Microsoft.AspNetCore.Mvc;

namespace SimulatorUI.Controllers;

public class GreenHouseSimulatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}