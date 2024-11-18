using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab_ASP_1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    [Required(ErrorMessage = "Prosze podać imię")]
    [MaxLength(length:20,ErrorMessage = "Imię nie może być dłużesz niż 20 znaków!")]
    [MinLength(length:2,ErrorMessage = "Imię nie może być krótsze niż 2 znaków!")]
    [Display(Name="Imię")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Prosze podać nazwisko")]
    [MaxLength(length:50,ErrorMessage = "Nazwisko nie może być dłużesz niż 50 znaków!")]
    [MinLength(length:2,ErrorMessage = "Imię nie może być krótsze niż 2 znaków!")]
    [Display(Name="Nazwisko")]
    public string LastName { get; set; }
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
    [DataType(DataType.Date)]
    [Display(Name ="Data urodzenia")]
    public DateOnly BirthDate { get; set; }
    [Phone]
    [RegularExpression("\\d\\d\\d \\d\\d\\d \\d\\d\\d",ErrorMessage="Wpisz numer wg wzoru:xxx xxx xxx")] 
    [Display(Name = "Numer telefonu")]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
    
    public int OrganizationId{ get; set; }
    public OrganizationEntity? Organization { get; set; }
    
    [ValidateNever]
    public List<SelectListItem> Organizations { get; set; }
    
    
}