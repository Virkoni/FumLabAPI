namespace FumLabAPI.Contracts.CustomPlushOrders
{
    public class GetCustomPlushOrdersResponse
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ContactInfo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
