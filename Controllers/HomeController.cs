using EntregaDispositivosMoveis.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaDispositivosMoveis.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Dashboard", "QuestTrack");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
    }
}
