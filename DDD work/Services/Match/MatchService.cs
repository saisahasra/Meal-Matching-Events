using System.Collections.Generic;
using System.Linq;
using DDD_work.Models;

namespace DDD_work.Services.Match
{
    public class MatchService
    {
        private readonly List<(long User1Id, long User2Id, long EventId)> _potentialMatches = new List<(long, long, long)>();
        private readonly List<(long User1Id, long User2Id, long EventId)> _mutualMatches = new List<(long, long, long)>();

        public void AddPotentialMatch(long user1Id, long user2Id, long eventId) // when someone swipes right for an event
        {
            if (user1Id != user2Id && !_potentialMatches.Contains((user1Id, user2Id, eventId)) && !_potentialMatches.Contains((user2Id, user1Id, eventId)))
            {
                _potentialMatches.Add((user1Id, user2Id, eventId)); // add this as a potential match
                CheckForMutualMatchInternal(user1Id, user2Id, eventId); // Call the internal method to check for mutual match
            }
        }

        private void CheckForMutualMatchInternal(long user1Id, long user2Id, long eventId)
        {
            if (_potentialMatches.Contains((user2Id, user1Id, eventId)))
            {
                _mutualMatches.Add((user1Id, user2Id, eventId));
                _potentialMatches.Remove((user1Id, user2Id, eventId)); // Remove from potential matches
                _potentialMatches.Remove((user2Id, user1Id, eventId)); // Remove the reverse as well
            }
        }

        public List<(long User1Id, long User2Id, long EventId)> GetPotentialMatches()
        {
            return _potentialMatches.ToList();
        }

        public List<(long User1Id, long User2Id, long EventId)> GetMutualMatches(long userId)
        {
            return _mutualMatches.Where(m => m.User1Id == userId || m.User2Id == userId).ToList();
        }

        public bool CheckForMutualMatch(long userId1, long userId2, long eventId) // Public method to check for mutual match for a specific event
        {
            return _potentialMatches.Contains((userId2, userId1, eventId));
        }

        public void RemovePotentialMatch(long userId1, long userId2, long eventId) // if someone swipes left or something
        {
            _potentialMatches.Remove((userId1, userId2, eventId)); // remove this potential match
            _potentialMatches.Remove((userId2, userId1, eventId)); // also remove the reverse if it exists
        }

        public void RemovePotentialMatchReverse(long userId1, long userId2, long eventId) // maybe if someone unmatches?
        {
            _potentialMatches.Remove((userId2, userId1, eventId)); // remove the reverse potential match
            // Consider also removing the forward match if a full "unmatch" scenario is desired.
        }
    }
}