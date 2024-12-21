namespace FumLabAPI.Contracts.ProductAvailability
{
    public class CreateProductAvailabilityRequest
    {
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}