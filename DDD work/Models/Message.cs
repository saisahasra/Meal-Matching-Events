namespace DDD_work.Models
{
    public class Message
    {
        public long MessageId { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}