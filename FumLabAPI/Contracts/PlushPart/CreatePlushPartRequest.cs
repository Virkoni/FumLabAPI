namespace FumLabAPI.Contracts.PlushPart
{
    public class CreatePlushPartRequest
    {
        public string PartName { get; set; }
        public int PartCategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
