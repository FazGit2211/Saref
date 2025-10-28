namespace Saref.Models.User
{
    public class User
    {
        protected internal int Id { get; set; }
        private string username;
        public string Username { get { return username; } set { if(value.Trim() != ""){ username = value; } } }
        private string password;
        public string Password { get { return password; } set { if (value.Trim() != "") { password = value; } } }
        protected internal byte[] Salt { get; set; }

    }
}
