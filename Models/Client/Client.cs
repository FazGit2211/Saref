using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Saref.Models.Client
{
    public class Client : IdentityUser
    {
        private string name;
        public string Name { get { return name; } set { if (value != null) { name = value; } } }

        private string email;

        public string Email { get { return email; } set { if (value != null) { email = value; } } }

        private int documentNumber;

        public int DocumentNumber { get { return documentNumber; } set { documentNumber = value; } }

        private string? address;
        public string Address { get { return address; } set { address = value; } }

        private PaymentMethod.PaymentMethod? paymentMethod;

        public PaymentMethod.PaymentMethod? PaymentMethod { get { return paymentMethod; } set { paymentMethod = value; } }

        [JsonIgnore]
        private List<Shift.Shift>? shiftsClient;

        [JsonIgnore]
        public List<Shift.Shift>? ShiftsClient { get { return shiftsClient; } set { shiftsClient = value; } }

    }
}
