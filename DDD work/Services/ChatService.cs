// DDD_work.Services/ChatService.cs
using System.Collections.Generic;
using System.Linq;
using DDD_work.Models;

namespace DDD_work.Services
{
    public class ChatService
    {
        private List<Message> _messages = new List<Message>();

        public void SendMessage(long senderId, long receiverId, string content)
        {
            _messages.Add(new Message
            {
                MessageId = _messages.Count + 1, // Simple ID generation
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content,
                Timestamp = DateTime.Now
            });
        }

        public List<Message> GetMessages(long user1Id, long user2Id)
        {
            return _messages.Where(m =>
                (m.SenderId == user1Id && m.ReceiverId == user2Id) ||
                (m.SenderId == user2Id && m.ReceiverId == user1Id))
                .OrderBy(m => m.Timestamp)
                .ToList();
        }
    }
}