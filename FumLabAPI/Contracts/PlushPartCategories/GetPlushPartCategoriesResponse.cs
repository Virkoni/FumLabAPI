namespace FumLabAPI.Contracts.PlushPartCategories
{
    public class GetPlushPartCategoriesResponse
    {
        public int Id { get; set; }
        public string PartCategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
