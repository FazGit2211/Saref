namespace Saref.Models.Stadium
{
    public class Stadium
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ushort Distance { get; set; }
        public ICollection<Shift.Shift> Shifts { get; set; }
    }
}
