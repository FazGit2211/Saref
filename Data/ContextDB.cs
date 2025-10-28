using Microsoft.EntityFrameworkCore;
using Saref.Models.Shift;
using Saref.Models.Stadium;
using Saref.Models.User;

namespace Saref.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(x => x.Id);
            modelBuilder.Entity<Stadium>().HasKey(s => s.Id);
            modelBuilder.Entity<Shift>().HasKey(sh => sh.Id);
        }
    }
}
