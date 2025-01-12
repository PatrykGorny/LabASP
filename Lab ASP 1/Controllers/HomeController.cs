using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab_ASP_1.Models;

namespace Lab_ASP_1.Controllers;

public class HomeController : Controller
{
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
    public IActionResult Calculator(Operator? op,double? a,double? b)
    {
        /*var op = Request.Query["op"];
        var a =double.Parse(Request.Query["a"]);
        var b = double.Parse(Request.Query["b"]);*/
        if (a is null || b is null)
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
        }
        return View();
    }
    /*
     *Zadanie 1
     * Zdefuniuj metodę Age,która na podstawie dwóch data w parametrach :birth,future
     * obliczy wiek osób w roku future
     * Uwzględnij pełen lata
     */
    public IActionResult Age(DateTime birth, DateTime future)
    {
        ViewBag.birth = birth;
        ViewBag.future = future;
        if (birth > future)
        {
            ViewBag.ErrorMessage = "Nie możesz być w przyszłości";
            return View("AgeError");
        }

        var dni = (future - birth).Days;
        ViewBag.Result = dni / 365;
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
public enum Operator
{
     Add,Sub,Mul,Div
}