using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Saref.Models.Client;
using Saref.Models.PaymentMethod;
using Saref.Models.Product;
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
        public DbSet<Product> Products { get; set; }
        public DbSet<Tshirt> Tshirts { get; set; }
        public DbSet<Shoes> Shoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasDiscriminator<string>("TypeDiscriminator").HasValue<Product>("Products").HasValue<Tshirt>("Tshirt").HasValue<Shoes>("Shoes");
            base.OnModelCreating(modelBuilder);
        }
    }
}
