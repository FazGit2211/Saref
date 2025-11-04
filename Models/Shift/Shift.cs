namespace Saref.Models.Shift
{
    public class Shift
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private DateOnly day;
        public DateOnly Day { get { return day; } set { day = value; } }

        private TimeOnly time;
        public TimeOnly Time { get { return time; } set { time = value; } }

        public static int CountShift = 0;

        public const int MAX_SHIFT = 10;

        private double price;
        public double Price { get { return price; } set { price = value; } }

        private int? stadiumId;
        enum StateShift { Reserved, Confirmed, Canceled, Done, Unassisted }

        public int? StadiumId { get { return stadiumId; } set { stadiumId = value; } }

        private int? clientId;

        public int? ClientId { get { return clientId; } set { clientId = value; } }



        public Shift(DateOnly day, TimeOnly time, double price)
        {
            this.Day = day;
            this.Time = time;
            CountShift++;
            this.Price = price;
        }
    }
}
