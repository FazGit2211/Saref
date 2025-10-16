namespace Saref.Models.Shift
{
    public class Shift
    {
        protected internal int Id { get; set; }
        protected internal DateOnly Day { get; set; }
        protected internal TimeOnly Time { get; set; }
        public static uint CountShift = 0;
        public const int MAX_SHIFT = 10;
        protected internal double Price { get; set; }
        protected internal int? StadiumId { get; set; }
        protected internal Saref.Models.Stadium.Stadium? Stadium { get; set; }

        public Shift(DateOnly day, TimeOnly time, double price)
        {
            this.Day = day;
            this.Time = time;
            CountShift++;
            this.Price = price;
        }
    }
}
