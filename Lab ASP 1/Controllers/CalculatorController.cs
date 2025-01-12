using Lab_ASP_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_ASP_1.Controllers;


public class CalculatorController : Controller
{
    
    /*public IActionResult Result(Calculator model)
    {
        /*if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b!";
            return View("CustomError");
        }
        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany Operator";
            return View("CustomError");
        }
        ViewBag.A = a;
        ViewBag.B = b;
    
        switch (op)
        {
            case Operator.Add:
                ViewBag.Result = a + b;
                ViewBag.Operator = "+"; 
                break;
            case Operator.Sub:
                ViewBag.Result = a - b;
                ViewBag.Operator = "-"; 
                break;
            case Operator.Div:
                ViewBag.Result = a / b;
                ViewBag.Operator = "/"; 
                break;
            case Operator.Mul:
                ViewBag.Result = a * b;
                ViewBag.Operator = "*"; 
                break; 
        }#1#
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
        
        
    }*/
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    public IActionResult Form()
    {
        return View();
    }


}