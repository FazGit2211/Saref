﻿namespace Saref.Models.Shift
{
    public class Shift
    {
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }
        public static uint CountShift = 0;
        public const int MAX_SHIFT = 10;
        public double Price { get; set; }
        public int? StadiumId { get; set; }
        public Saref.Models.Stadium.Stadium? Stadium { get; set; }

        public Shift(DateOnly day, TimeOnly time, double price)
        {
            this.Day = day;
            this.Time = time;
            CountShift++;
            this.Price = price;
        }
    }
}
