namespace Saref.Models.Product
{
    public abstract class Product
    {
        private int id;
        public int Id { get { return id; } set { if (value > 0) { id = value; } } }
        private string name;
        public string Name { get { return name; } set { if (value != "") { name = value; } } }
        private string description;
        public string Description { get { return description; } set { if (value != "") { description = value; } } }
        private float price;
        public float Price { get { return price; } set { if (value > 0) { price = value; } } }
    }
}
