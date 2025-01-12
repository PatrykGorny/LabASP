using Lab_ASP_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_ASP_1.Controllers;

public class BirthController : Controller
{
  
    [HttpGet]
    public IActionResult Birth()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result([FromForm] Birth model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }

        return View("Result", model);
    }
}