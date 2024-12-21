namespace FumLabAPI.Contracts.Payment
{
    public class GetPaymentResponse
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}