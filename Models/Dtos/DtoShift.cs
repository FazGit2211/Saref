namespace Saref.Models.Dtos
{
    public class DtoShift
    {
        protected internal int Id { get; set; }
        protected internal DateOnly Day { get; set; }
        protected internal TimeOnly Time { get; set; }
        protected internal double Price { get; set; }
        static uint CountShift { get; set; }

    }
}
