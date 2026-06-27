using EntregaDispositivosMoveis.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntregaDispositivosMoveis.Controllers;

public class QuestTrackController : Controller
{
    private readonly PrototypeDataService _prototypeDataService;

    public QuestTrackController(PrototypeDataService prototypeDataService)
    {
        _prototypeDataService = prototypeDataService;
    }

    public IActionResult Dashboard()
    {
        return View(_prototypeDataService.GetDashboard());
    }

    public IActionResult Create()
    {
        return View("SessionForm", _prototypeDataService.GetCreateForm());
    }

    public IActionResult History()
    {
        return View(_prototypeDataService.GetHistory());
    }

    public IActionResult Edit(int id = 1)
    {
        return View("SessionForm", _prototypeDataService.GetEditForm(id));
    }

    public IActionResult Stats()
    {
        return View(_prototypeDataService.GetStats());
    }

    public IActionResult Delete(int id = 1)
    {
        return View(_prototypeDataService.GetDeleteConfirmation(id));
    }
}
