using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab_ASP_1.Models;

public class Book
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage ="Proszę podać tytuł!")]
    public string Title { get; set; }
    
    [Required(ErrorMessage ="Proszę podać autora!")]
    public string Author { get; set; }
    
    [Required(ErrorMessage ="Proszę podać liczbe stron!")]
    public string Page{ get; set; }
    
    
    [MaxLength(length:13, ErrorMessage ="Wiadomość może mieć max 13 znaków!")]
    [MinLength(length:10, ErrorMessage ="Wiadomość musi mieć  min 10 znaków!")]
    [Required(ErrorMessage ="Proszę wpisz ISBN!")]
    public string ISBN { get; set; }
    
    
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage ="Proszę podać wydawnictwo!")]
    public string Publisher { get; set; }
    
}