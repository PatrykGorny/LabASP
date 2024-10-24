using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab_ASP_1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    [Required(ErrorMessage = "Prosze podać imię")]
    [MaxLength(length:20,ErrorMessage = "Imię nie może być dłużesz niż 20 znaków!")]
    [MinLength(length:2,ErrorMessage = "Imię nie może być krótsze niż 2 znaków!")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Prosze podać nazwisko")]
    [MaxLength(length:50,ErrorMessage = "Nazwisko nie może być dłużesz niż 50 znaków!")]
    [MinLength(length:2,ErrorMessage = "Imię nie może być krótsze niż 2 znaków!")]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
    [Phone]
    [RegularExpression("\\d\\d\\d \\d\\d\\d \\d\\d\\d",ErrorMessage="Wpisz numer wg wzoru:xxx xxx xxx")] 
    public string PhoneNumber { get; set; }
    
}