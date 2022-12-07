using Microsoft.EntityFrameworkCore;
using MyStatTagHelpers.Models;


namespace MyStatTagHelpers.Services
{
    public class HomeWorkDbContext : DbContext
    {
        public HomeWorkDbContext(DbContextOptions<HomeWorkDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HomeWorkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomeWork>().HasData(new HomeWork[1] { new HomeWork { Title = "MVC", CreatedDate = DateTime.Now, File = "MyHWMVCproject", Id = 1 } });
            modelBuilder.Entity<User>().HasData(new User[1] { new User { Name = "Admin", Surname = "Admin", Password = "Admin" } });
        }

    }

}
