namespace FumLabAPI.Contracts.Reviews
{
    public class CreateReviewRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public bool IsDeleted { get; set; }

    }
}
