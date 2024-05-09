using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROYECTO.Models;

namespace PROYECTO.Controllers;

public class HomeController : Controller
{

    const string apiUrl = "https://weather.com/es-ES/tiempo/horario/l/56820516c3f1b23cd5b7ad2dd3b6045ca3b480f6cc160e75b858c99548b7c02e";
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger; 
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
