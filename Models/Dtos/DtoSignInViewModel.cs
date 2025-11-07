using System.Net;

namespace Saref.Models.Dtos
{
    public class DtoSignInViewModel : DtoLoginViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public int DocumentNumber { get; set; }

        public string Address { get; set; }
    }
}
