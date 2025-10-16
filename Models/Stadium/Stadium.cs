namespace Saref.Models.Stadium
{
    public class Stadium
    {

        protected internal int Id { get; set; }
        protected internal string Name { get; set; }
        protected internal string Address { get; set; }
        protected internal ushort Distance { get; set; }

        protected internal ICollection<Shift.Shift>? Shifts { get; set; }
    }
}
