using Microsoft.EntityFrameworkCore;
using MystatHtmlHelpers.Models;


namespace MystatHtmlHelpers.Server
{
    public class HomeWorkDbContext : DbContext
    {
        public HomeWorkDbContext(DbContextOptions<HomeWorkDbContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<HomeWork> HomeWorks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HomeWorkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomeWork>().HasData(new HomeWork[1] { new HomeWork { Title = "MVC", CreatedDate = DateTime.Now, File = "MyHWMVCproject", Id =1 } }) ;
           
        }

    }

}
