namespace FumLabAPI.Contracts.PlushPart
{
    public class GetPlushPartResponse
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public int PartCategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}