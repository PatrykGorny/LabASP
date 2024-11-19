using Lab_ASP_1.Models;
using Lab_ASP_1.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab_ASP_1.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    /*private static Dictionary<int, ContactModel> _contacts = new()
    {
        { 1, new ContactModel {Id=1, FirstName = "Patryk", LastName = "Kowalski", Email = "patryk@o2.pl", BirthDate = new DateOnly(2003, 01, 13), PhoneNumber = "666 666 666" } },
        { 2, new ContactModel {Id=2, FirstName = "Michał", LastName = "Nowak", Email = "michal@o2.pl", BirthDate = new DateOnly(2003, 05, 12), PhoneNumber = "999 999 999" } },
        { 3, new ContactModel {Id=3, FirstName = "Jakub", LastName = "Jankowski", Email = "jakub@o2.pl", BirthDate = new DateOnly(2003, 11, 02), PhoneNumber = "222 333 444" } }
    };


    private static int currentId = 3;
    // Lista kontaktów */
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }
    //Formularz dodania kontaktu 
    [HttpGet]
    public IActionResult Add()
    {
        var model = new ContactModel();
        model.Organizations=_contactService.GetOrganizations().Select(i=>new SelectListItem()
        {
            Value = i.Id.ToString(),
            Text = i.Name,
            Selected = i.Id == 1    
        }).ToList();
        return View(model);
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
            /*model.Id = ++currentId;
            _contacts.Add(model.Id, model);*/
            _contactService.Add(model);
            return RedirectToAction(nameof(Index));
            /*return View("Index", _contacts.Values.ToList());   */ 
        }
    }

    public IActionResult Delete(int id,ContactModel model)
    {
        /*_contacts.Remove(id);
        return View("Index", _contacts.Values.ToList());*/
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        /*if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        return NotFound();*/
        /*return View(_contactService.GetById(id));*/
        
        var contact = _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }

        contact.Organizations = _contactService
            .GetOrganizations()
            .Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Name })
            .ToList();

        return View(contact);
    }

    [HttpPost]
    public IActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Update(model);
        return RedirectToAction("Index");
        /*
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (_contacts.ContainsKey(model.Id))
        {
            _contacts[model.Id] = model;
            return RedirectToAction("Index");
        }
        return NotFound();*/
     
    }
    public IActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
        /*if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        return NotFound();*/
    }
    
    
}