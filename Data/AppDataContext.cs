using EventManager.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<EventModel> Events { get; set; }
        public DbSet<LocalityModel> Localities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EventManagerSys;User ID=sa;Password=Banano2@;TrustServerCertificate=True;");
        }
    }
}
