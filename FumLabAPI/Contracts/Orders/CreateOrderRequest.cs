namespace FumLabAPI.Contracts.Orders
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
