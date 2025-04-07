
using System.Collections.Generic;

namespace DDD_work.Models
{
    public class GroupChat
    {
        public long GroupChatId { get; set; }
        public string? GroupName { get; set; }
        public List<long> UserIds { get; set; } = new List<long>();
    }
}