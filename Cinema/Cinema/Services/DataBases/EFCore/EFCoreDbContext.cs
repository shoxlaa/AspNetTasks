using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.DataBases.EFCore
{
    public class EFCoreDbContext :DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }

}
