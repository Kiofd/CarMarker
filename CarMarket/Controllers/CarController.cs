using CarMarket.DAL.Interfaces;
using CarMarket.Domain.Entity_Models_;
using CarMarket.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;
    
    
    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var response = await _carService.GetCars();
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        { 
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }

    public IActionResult Error()
    {
        throw new NotImplementedException();
    }
}