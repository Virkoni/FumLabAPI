namespace FumLabAPI.Contracts.Orders
{
    public class GetOrderResponse
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}