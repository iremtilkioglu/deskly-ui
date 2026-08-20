using Microsoft.AspNetCore.Mvc;

namespace deskly_ui.Controllers;

public class BlogController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Detail(int id)
    {
        return View();
    }
}