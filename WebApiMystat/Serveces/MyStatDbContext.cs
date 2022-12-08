using Bogus;
using Microsoft.EntityFrameworkCore;
using WebApiMystat.Models;

namespace WebApiMystat.Serveces; 


public class MyStatDbContext :DbContext
{
    public  MyStatDbContext(DbContextOptions<MyStatDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<HomeWork> HomeWorks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        int id = 1;
        var faker = new Faker<User>();
        var users = faker.RuleFor(u => u.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Surname, f => f.Person.LastName)
            .RuleFor(u => u.Password, f => f.Random.Words(2))
            .Generate(10);
        
        var fakerHw = new Faker<HomeWork>();
        var hw = fakerHw.RuleFor(h => h.Title, f => f.Hacker.Noun())
            .RuleFor(h => h.File, f => f.Hacker.Verb())
            .Generate(10);

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<HomeWork>().HasData(hw);
    }
}