namespace FumLabAPI.Contracts.Message
{
    public class GetMessageResponse
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}