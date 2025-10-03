using Microsoft.AspNetCore.Mvc;

namespace GreenHouseApi.Controllers;

public class GreenHouseController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}