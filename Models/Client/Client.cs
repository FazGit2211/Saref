namespace Saref.Models.Client
{
    public class Client
    {

        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string email;

        public string Email { get { return email; } set { email = value; } }

        private int documentNumber;

        public int DocumentNumber { get { return documentNumber; } set { documentNumber = value; } }

        private string? address;
        public string Address { get { return address; } set { address = value; } }

        private PaymentMethod.PaymentMethod? paymentMethod;

        public PaymentMethod.PaymentMethod? PaymentMethod { get { return paymentMethod; } set { paymentMethod = value; } }

        private List<Shift.Shift>? shiftsClient;

        public List<Shift.Shift>? ShiftsClient { get { return shiftsClient; } set { shiftsClient = value; } }

        private int usuarioId;

        public int UsuarioId { get { return usuarioId; } set { usuarioId = value; } }

        private User.User? user;
        public User.User? User { get { return user; } set { user = value; } }
    }
}
