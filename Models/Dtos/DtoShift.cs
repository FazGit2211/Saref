namespace Saref.Models.Dtos
{
    public class DtoShift
    {
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }
        public float Price { get; set; }

        private Stadium.Stadium? stadium;
        public Stadium.Stadium? Stadium { get { return stadium; } set { stadium = value; } }

        private Client.Client? client;

        public Client.Client? Client { get { return client; } set { client = value; } }
        public DtoShift(DateOnly day, TimeOnly time, float price, Stadium.Stadium paramStadium)
        {
            this.Day = day;
            this.Time = time;
            this.Price = price;
            this.Stadium = paramStadium;
        }
        public DtoShift(DateOnly day, TimeOnly time, float price, Stadium.Stadium paramStadium, Client.Client paramClient)
        {
            this.Day = day;
            this.Time = time;
            this.Price = price;
            this.Stadium = paramStadium;
            this.Client = paramClient;
        }

    }
}
