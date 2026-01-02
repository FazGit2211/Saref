using System.Text.Json.Serialization;

namespace Saref.Models.Shift
{
    public class Shift
    {
        private int id;
        public int Id { get { return id; } set { if (value > 0) { id = value; } } }
        private DateOnly day;
        public DateOnly Day { get { return day; } set { day = value; } }

        private TimeOnly time;
        public TimeOnly Time { get { return time; } set { time = value; } }

        public static int CountShift = 0;

        private float price;
        public float Price { get { return price; } set { if (value > 0) { price = value; } } }

        private string state;

        public string State { get { return state; } set { if (!value.Trim().Equals("")) { state = value; } } }

        public enum StateShift : byte { reserved, available, pending }
        public int StadiumId { get; set; }

        [JsonIgnore]
        private Stadium.Stadium stadium;

        [JsonIgnore]
        public Stadium.Stadium Stadium { get { return stadium; } set { if (value != null) { stadium = value; } } }


        private Client.Client? client;

        public Client.Client? Client { get { return client; } set { if (value != null) { client = value; } } }

        public Shift() { }
        public Shift(DateOnly day, TimeOnly time, float price, Stadium.Stadium paramStadium)
        {
            this.Day = day;
            this.Time = time;
            CountShift++;
            this.Price = price;
            this.Stadium = paramStadium;
        }
        public static string ConvertStateShift(byte state)
        {
            string convertStateShift = "";
            switch (state)
            {
                case 0: convertStateShift = "Reserved"; break;
                case 1: convertStateShift = "Availabled"; break;
                case 2: convertStateShift = "Pending"; break;
            }
            return convertStateShift;
        }
    }
}
