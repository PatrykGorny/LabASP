using Lab_ASP_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_ASP_1.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int,ContactModel> _contacts = new()
    {
        {1,new ContactModel{FirstName="Patryk", 
            LastName="Kowalski",
            Email = "patryk@o2.pl",
            BirthDate = new DateOnly(2003,01, 13),
            PhoneNumber = "666 666 666"} },
        {2,new ContactModel{FirstName="Miachał", 
            LastName="Nowak",
            Email = "michal@o2.pl",
            BirthDate = new DateOnly(2003,05, 12),
            PhoneNumber = "999 999 999"} },
        {3,new ContactModel{FirstName="Jakub", 
            LastName="Jankowski",
            Email = "jakub@o2.pl",
            BirthDate = new DateOnly(2003,11, 02),
            PhoneNumber = "222 333 444"} }
    };

    private static int currentId = 3;
    // Lista kontaktów 
    public IActionResult Index()
    {
        return View(_contacts);
    }
    //Formularz dodania kontaktu 
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        else
        {
            model.Id = ++currentId;
            _contacts.Add(model.Id, model);
            return View("Index", _contacts);    
        }
        
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }
    
    
}