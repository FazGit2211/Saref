namespace Saref.Models.Stadium
{
    public class Stadium
    {

        protected internal int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ushort Distance { get; set; }

        protected internal ICollection<Shift.Shift>? Shifts { get; set; }
    }
}
