using System.Net;

namespace Saref.Models.Dtos
{
    public class DtoSignInViewModel : DtoLoginViewModel
    {
        private string name;
        public string Name { get { return name; } set { if (!value.Trim().Equals("")) { name = value; } } }

        private string email;
        public string Email { get { return email; } set { if (!value.Trim().Equals("")) { email = value; } } }

        private int dni;
        public int DocumentNumber { get { return dni; } set { if (value > 0) { dni = value; } } }

        private string address;
        public string Address { get { return address; } set { if (!value.Trim().Equals("")) { address = value; } } }
    }
}
