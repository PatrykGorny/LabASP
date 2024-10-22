using Lab_ASP_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_ASP_1.Controllers;

public class BookController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            return View();
        }
        else
        {
            return View();
        }
    }
    
    public IActionResult Index()
    {
        return View();
    }
}