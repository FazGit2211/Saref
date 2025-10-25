namespace Saref.Models.PaymentMethod
{
    public class Card : PaymentMethod
    {
        int Number { get; set; }
        DateOnly ExpirationDate { get; set; }
        int Cvv { get; set; }
    }
}
