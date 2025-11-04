namespace Saref.Models.User
{
    public class User
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string username;
        public string Username { get { return username; } set { if (value.Trim() != "") { username = value; } } }
        
        private string password;
        public string Password { get { return password; } set { if (value.Trim() != "") { password = value; } } }

    }
}
