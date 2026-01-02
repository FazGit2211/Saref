using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Saref.Models.Client;
using Saref.Models.PaymentMethod;
using Saref.Models.Shift;
using Saref.Models.Stadium;

namespace Saref.Data
{
    public class ContextDB : IdentityDbContext<Client>
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BankTransfer> BankTransfer { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Stadium>().HasMany(shift => shift.Shifts).WithOne(st => st.Stadium).HasForeignKey(shift => shift.StadiumId).HasPrincipalKey(st => st.Id).IsRequired();
        }
    }
}
