using Capstone.Model;
using Microsoft.EntityFrameworkCore;

namespace Capstone.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Slot> Slot { get; set; }
        public DbSet<Servizi> Servizi { get; set; }
        public DbSet<SelezioneServizi> SelezioneServizi { get; set; }
        public DbSet<Recensioni> Recensioni { get; set; }
        public DbSet<Giorno> Giorni { get; set; }
        public DbSet<Azienda> Azienda { get; set; }

    }
}
