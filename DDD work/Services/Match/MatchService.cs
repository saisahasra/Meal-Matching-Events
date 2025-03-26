using System.Collections.Generic;
using System.Linq;
using DDD_work.Models;

namespace DDD_work.Services.Match
{
    public class MatchService
    {
        private readonly List<(long User1Id, long User2Id)> _potentialMatches = new List<(long, long)>();

        public void AddPotentialMatch(long user1Id, long user2Id)
        {
            _potentialMatches.Add((user1Id, user2Id));
        }

        public bool CheckForMutualMatch(long userId1, long userId2)
        {
            return _potentialMatches.Contains((userId2, userId1));
        }

        public void RemovePotentialMatch(long userId1, long userId2)
        {
            _potentialMatches.Remove((userId1, userId2));
        }

        public void RemovePotentialMatchReverse(long userId1, long userId2)
        {
            _potentialMatches.Remove((userId2, userId1));
        }

        public List<(long User1Id, long User2Id)> GetPotentialMatches()
        {
            return _potentialMatches;
        }
    }
}