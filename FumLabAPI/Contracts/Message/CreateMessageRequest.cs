namespace FumLabAPI.Contracts.Message
{ 
    public class CreateMessageRequest
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string MessageText { get; set; }
    }
}
