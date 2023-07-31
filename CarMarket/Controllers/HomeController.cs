using System.Diagnostics;
using CarMarket.DAL.Interfaces;
using CarMarket.Domain.Entity_Models_;
using Microsoft.AspNetCore.Mvc;
using CarMarket.Models;

namespace CarMarket.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


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