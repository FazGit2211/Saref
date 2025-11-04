namespace Saref.Models.Stadium
{
    public class Stadium
    {

        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string? name;
        public string Name { get { return name; } set { name = value; } }

        private string? address;
        public string Address { get { return address; } set { address = value; } }

        private ushort distance;
        public ushort Distance { get { return distance; } set { distance = value; } }

        private List<Shift.Shift>? shifts;
        public List<Shift.Shift>? Shifts { get { return shifts; } set { shifts = value; } }


    }
}
