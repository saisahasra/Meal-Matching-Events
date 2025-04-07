using System.Collections.Generic;
using System.Linq;
using DDD_work.Models;

namespace DDD_work.Services
{
    public class GroupChatService
    {
        private List<GroupChat> _groupChats = new List<GroupChat>();

        public GroupChat CreateGroupChat(string groupName, List<long> userIds)
        {
            var groupChat = new GroupChat
            {
                GroupChatId = _groupChats.Count + 1,
                GroupName = groupName,
                UserIds = userIds
            };
            _groupChats.Add(groupChat);
            return groupChat;
        }

        public GroupChat GetGroupChat(long groupChatId)
        {
            return _groupChats.FirstOrDefault(g => g.GroupChatId == groupChatId);
        }

        public List<GroupChat> GetGroupChatsForUser(long userId)
        {
            return _groupChats.Where(g => g.UserIds.Contains(userId)).ToList();
        }

        public void AddUserToGroupChat(long groupChatId, long userId)
        {
            var groupChat = GetGroupChat(groupChatId);
            if (groupChat != null && !groupChat.UserIds.Contains(userId))
            {
                groupChat.UserIds.Add(userId);
            }
        }
    }
}