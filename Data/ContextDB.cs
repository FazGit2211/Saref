using Microsoft.EntityFrameworkCore;
using Saref.Models.Client;
using Saref.Models.PaymentMethod;
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
        public DbSet<Client> Clients { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BankTransfer> BankTransfer { get; set; }
        public DbSet<Card> Cards { get; set; }

    }
}
