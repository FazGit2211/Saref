using Microsoft.EntityFrameworkCore;
using Saref.Models.Shift;
using Saref.Models.Stadium;

namespace Saref.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Shift> Shifts { get; set; }
    }
}
