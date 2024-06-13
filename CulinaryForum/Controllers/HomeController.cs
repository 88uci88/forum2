using CulinaryForum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CulinaryForum.Controllers;

public class HomeController() : Controller // ILogger<HomeController> logger
{
    //private readonly ILogger<HomeController> _logger = logger;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}