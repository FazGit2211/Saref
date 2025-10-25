namespace Saref.Models.Client
{
    public class Client
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        int DocumentNumber { get; set; }
        string Address { get; set; }
        PaymentMethod.PaymentMethod? PaymentMethod { get; set; }
        List<Shift.Shift> ShiftsClient { get; set; }
    }
}
