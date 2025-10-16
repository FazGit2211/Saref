namespace Saref.Models.Dtos
{
    public class DtoShift
    {
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }
        public double Price { get; set; }

    }
}
