namespace Saref.Models.Dtos
{
    public class DtoShift
    {
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }
        public float Price { get; set; }

        private int? stadiumId;
        public int? StadiumId { get { return stadiumId; } set { stadiumId = value; } }

        private Stadium.Stadium? stadium;
        public Stadium.Stadium? Stadium { get { return stadium; } set { stadium = value; } }

        private int? clientId;

        public int? ClientId { get { return clientId; } set { clientId = value; } }


        private Client.Client? client;

        public Client.Client? Client { get { return client; } set { client = value; } }
        public DtoShift(int id, DateOnly day, TimeOnly time, float price, Stadium.Stadium paramStadium, Client.Client paramClient)
        {
            Id = id;
            Day = day;
            Time = time;
            Price = price;
            Stadium = paramStadium;
            Client = paramClient;
        }


    }
}
