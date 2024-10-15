namespace FumLabAPI.Contracts.ProductAvailability
{
    public class GetProductAvailabilityResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
