using Microsoft.AspNetCore.Mvc;

namespace deskly_ui.Controllers;

public class ConfiguratorController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}