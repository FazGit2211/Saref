namespace Saref.Models.User
{
    public class User
    {
        protected internal int Id { get; set; }
        protected internal string Username { get; set; }
        protected internal string Password { get; set; }
        protected internal byte[] Salt { get; set; }

    }
}
