namespace FumLabAPI.Contracts.Payment
{
    public class CreatePaymentRequest
    {
        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}