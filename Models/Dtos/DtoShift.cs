namespace Saref.Models.Dtos
{
    public class DtoShift
    {
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }
        public float Price { get; set; }

        public List<Shift.Shift> shifts { get; set; }
        public DtoShift(int id, DateOnly day, TimeOnly time, float price)
        {
            Id = id;
            Day = day;
            Time = time;
            Price = price;
        }

        public DtoShift()
        {
            shifts = new List<Shift.Shift>();
        }

    }
}
