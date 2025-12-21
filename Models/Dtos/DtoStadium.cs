using System.ComponentModel.DataAnnotations;

namespace Saref.Models.Dtos
{
    public class DtoStadium
    {
        [Required(ErrorMessage = "Nombre no puede estar vacio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Direccion no puede estar vacio")]
        public string Address { get; set; }
    }
}
