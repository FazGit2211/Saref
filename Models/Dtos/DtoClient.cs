namespace Saref.Models.Dtos
{
    public class DtoClient
    {        

        private string name;
        public string Name { get { return name; } set { if (!value.Trim().Equals("")) { name = value; } } }

        private string email;

        public string Email { get { return email; } set { if (!value.Trim().Equals("")) { email = value; } } }

        private int documentNumber;

        public int DocumentNumber { get { return documentNumber; } set { if (documentNumber > 0) { documentNumber = value; } } }

        private string address;
        public string Address { get { return address; } set { if (!value.Trim().Equals("")) { address = value; } } }

        private string username;
        public string Username { get { return username; } set { if (!value.Trim().Equals("")) { username = value; } } }
    }
}
