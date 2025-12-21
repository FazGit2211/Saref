using System.ComponentModel.DataAnnotations;

namespace Saref.Models.Dtos
{
    public class DtoShift
    {
        [Required(ErrorMessage = "Día no puede estar vacio")]
        public DateOnly Day { get; set; }
        [Required(ErrorMessage = "Hora no puede estar vacio")]
        public TimeOnly Time { get; set; }
        [Required(ErrorMessage = "Precio no puede estar vacio")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Estadio no puede estar vacio")]
        public int StadiumId { get; set; }
        public string? State { get; set; }

        public DtoShift(DateOnly day, TimeOnly time, float price)
        {
            this.Day = day;
            this.Time = time;
            this.Price = price;
        }

        public DtoShift() { }

    }
}
