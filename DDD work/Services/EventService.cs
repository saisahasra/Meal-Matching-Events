using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD_work.Models;

namespace DDD_work.Services
{
    public class EventService
    {
        private readonly List<Event> _events = new List<Event>()
    {
        new Event { Id = 1, Name = "Book Club", DateTime = DateTime.Now.AddDays(10), Location = "University of Hull Library", Description = "Reading 'The Great Gatsby'. Join us for a lively discussion!", PictureUrl = "https://www.oxfordscholastica.com/wp-content/uploads/2024/03/book-club.webp" },
        new Event { Id = 2, Name = "Hiking Trip", DateTime = DateTime.Now.AddDays(14), Location = "Humber Bridge Country Park", Description = "A scenic hike in the beautiful Humber Bridge Country Park. Bring sturdy shoes and water!", PictureUrl = "https://cdn.outsideonline.com/wp-content/uploads/2023/04/guided-hike_sq.jpg" },
        new Event { Id = 3, Name = "Karaoke Night", DateTime = DateTime.Now.AddDays(21), Location = "The Welly Club - Hull City Centre", Description = "Unleash your inner superstar at Karaoke Night! All levels of singing talent welcome.", PictureUrl = "https://m.media-amazon.com/images/I/71SFecSvQVL.jpg" }
    };

        private readonly Dictionary<long, List<string>> _userNotifications = new Dictionary<long, List<string>>();

        public async Task<List<Event>> GetEventsAsync()
        {
            await Task.Delay(100);
            return _events;
        }

        public async Task<Event?> GetEventByIdAsync(long id)
        {
            await Task.Delay(100);
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public async Task<bool> JoinEvent(long eventId, long userId)
        {
            var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
            if (eventItem == null || eventItem.Attendees.Contains(userId))
                return false; // Event not found or user already joined

            eventItem.Attendees.Add(userId);


            await MatchUsers(eventItem, userId);

            return true;
        }

        public async Task CreateEvent(Event newEvent)
        {
            newEvent.Id = _events.Count + 1; // Simple ID generation
            _events.Add(newEvent);
        }

        public async Task MatchUsers(Event eventItem, long userId)
        {
            var matchedUsers = eventItem.Attendees.Where(uid => uid != userId).ToList();
            if (matchedUsers.Count > 0)
            {
                string matchMessage = $"You matched with {matchedUsers.Count} other attendee(s) for {eventItem.Name}!";
                AddNotification(userId, matchMessage);

                // Notify all matched users
                foreach (var matchedUserId in matchedUsers)
                {
                    AddNotification(matchedUserId, $"New match! User {userId} is also attending {eventItem.Name}.");
                }
            }
        }

        private void AddNotification(long userId, string message)
        {
            if (!_userNotifications.ContainsKey(userId))
                _userNotifications[userId] = new List<string>();

            _userNotifications[userId].Add(message);
        }

        public async Task<List<string>> GetNotifications(long userId)
        {
            await Task.Delay(100);
            return _userNotifications.ContainsKey(userId) ? _userNotifications[userId] : new List<string>();
        }
    }

}