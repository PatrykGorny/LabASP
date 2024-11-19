using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab_ASP_1.Models;

public class AppDbContext: IdentityDbContext<IdentityUser>
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
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
        base.OnModelCreating(modelBuilder);
        string User_ID= Guid.NewGuid().ToString();
        string Admin_ID= Guid.NewGuid().ToString();
        string User_Role_ID= Guid.NewGuid().ToString();
        string Admin_Role_ID= Guid.NewGuid().ToString();
        
        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole(){Id=User_ID,Name ="user",NormalizedName ="USER",ConcurrencyStamp = User_Role_ID},
                new IdentityRole(){Id=Admin_Role_ID,Name ="admin",NormalizedName ="Admin",ConcurrencyStamp = Admin_Role_ID}
                );
        var user = new IdentityUser()
        {
            Id = User_ID,
            Email = "patryk@wsei.edu.pl",
            NormalizedEmail = "PATRYK@WSEI.EDU.Pl",
            UserName = "patryk",
            NormalizedUserName = "PATRYK",
            EmailConfirmed = true,
            
        };
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        hasher.HashPassword(user, "zaq123@");
        var admin= new IdentityUser()
        {
            Id = Admin_ID,
            Email = "admin@wsei.edu.pl",
            NormalizedEmail = "ADMIN@WSEI.EDU.Pl",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            EmailConfirmed = true,
            
        };
        hasher.HashPassword(admin, "admin123");
        modelBuilder.Entity<IdentityUser>().HasData(user,admin);
        modelBuilder.Entity<IdentityUser<string>>()
            .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId=Admin_Role_ID,
                    UserId=Admin_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId=User_Role_ID,
                    UserId=User_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId=User_Role_ID,
                    UserId=Admin_ID
                }
            );
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
            new OrganizationEntity
            {
                Id = 101,
                Name = "Wsei",
                NIP = "283792834",
                REGION = "2427381273"
            },
            new OrganizationEntity
            {
                Id = 102,
                Name = "PKP",
                NIP = "2834792834",
                REGION = "2422181273"
            });
        modelBuilder.Entity<OrganizationEntity>().OwnsOne(e => e.Address)
            .HasData(
                new{OrganizationEntityId =101,City="Kraków",Street="św. Silipa17"},
                new{OrganizationEntityId =102,City="Warszawa",Street="Dworcowa 9"});
       
        
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c=>c.Organization)
            .WithMany(o=>o.Contacts)
            .HasForeignKey(c=>c.OrganizationId);
        modelBuilder.Entity<ContactEntity>()
             
            .HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Patrick",
                LastName = "Nowak",
                BirthDate = new(2000, 10, 10),
                PhoneNumber = "666666666",
                Email = "patryk@o2.pl",
                Created = DateTime.Now,
                OrganizationId = 101
            }, new ContactEntity(){
                Id = 2,
                FirstName = "Michał",
                LastName = "Kowalski",
                BirthDate = new(2003, 09, 09),
                PhoneNumber = "666666666",
                Email = "patryk@o2.pl",
                Created = DateTime.Now,
                OrganizationId=102
            }
            );
    }
}
