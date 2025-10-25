namespace Saref.Models.PaymentMethod
{
    public abstract class PaymentMethod
    {
        int Id { get; set; }
        DateOnly Date  {get; set;}
    }
}
