using System.Collections.Generic;
using System.Linq;
using DDD_work.Models;

namespace DDD_work.Services.Match
{
    public class MatchService
    {
        private readonly List<(long User1Id, long User2Id, long EventId)> _potentialMatches = new List<(long, long, long)>();
        private readonly List<(long User1Id, long User2Id, long EventId)> _mutualMatches = new List<(long, long, long)>();

        public void AddPotentialMatch(long user1Id, long user2Id, long eventId)
        {
            if (user1Id != user2Id && !_potentialMatches.Contains((user1Id, user2Id, eventId)) && !_potentialMatches.Contains((user2Id, user1Id, eventId)))
            {
                _potentialMatches.Add((user1Id, user2Id, eventId));
            }
        }

        public bool CheckForMutualMatch(long user1Id, long user2Id, long eventId)
        {
            return _potentialMatches.Contains((user2Id, user1Id, eventId));
        }

        public void AddMutualMatch(long user1Id, long user2Id, long eventId)
        {
            if (!_mutualMatches.Contains((user1Id, user2Id, eventId)) && !_mutualMatches.Contains((user2Id, user1Id, eventId)))
            {
                _mutualMatches.Add((user1Id, user2Id, eventId));
            }
        }

        public List<(long User1Id, long User2Id, long EventId)> GetMutualMatches(long userId)
        {
            return _mutualMatches.Where(m => m.User1Id == userId || m.User2Id == userId).ToList();
        }
    }
}