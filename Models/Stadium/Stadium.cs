namespace Saref.Models.Stadium
{
    public class Stadium
    {

        private int id;
        public int Id { get { return id; } set { if (value > 0) { id = value; } } }

        private string name;
        public string Name { get { return name; } set { if (value != "") { name = value; } } }

        private string address;
        public string Address { get { return address; } set { if (value != "") { address = value; } } }


        private List<Shift.Shift>? shifts;
        public List<Shift.Shift>? Shifts { get { return shifts; } set { shifts = value; } }


    }
}
