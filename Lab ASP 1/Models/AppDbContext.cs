using Microsoft.EntityFrameworkCore;

namespace Lab_ASP_1.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
        

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Patrick",
                LastName = "Nowak",
                BirthDate = new(2000, 10, 10),
                PhoneNumber = "666666666",
                Email = "patryk@o2.pl",
                Created = DateTime.Now
            }, new ContactEntity(){
                Id = 2,
                FirstName = "Michał",
                LastName = "Kowalski",
                BirthDate = new(2003, 09, 09),
                PhoneNumber = "666666666",
                Email = "patryk@o2.pl",
                Created = DateTime.Now
            }
            
   
            
            
            );
    }
}