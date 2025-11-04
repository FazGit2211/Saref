namespace Saref.Models.PaymentMethod
{
    public abstract class PaymentMethod
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
    }
}
