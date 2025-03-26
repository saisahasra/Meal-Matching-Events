namespace DDD_work.Models
{
    public class ChatMessage
    {
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
        public string? Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}