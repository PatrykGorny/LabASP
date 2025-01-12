namespace Lab_ASP_1.Models;

public class Birth
{
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }

    // Sprawdza, czy model jest prawidłowy
    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Name) && DateOfBirth != null && DateOfBirth < DateTime.Now;
    }

    // Metoda obliczająca wiek
    public int CalculateAge()
    {
        if (DateOfBirth == null) return 0;

        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Value.Year;
            
        if (DateOfBirth.Value.Date > today.AddYears(-age)) age--;

        return age;
    }
}