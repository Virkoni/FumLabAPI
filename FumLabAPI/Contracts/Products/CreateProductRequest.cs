namespace FumLabAPI.Contracts.Products
{
    public class CreateProductRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
