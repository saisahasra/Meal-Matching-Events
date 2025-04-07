using DDD_work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD_work.Services
{
    public class MealMatchService
    {
        private readonly List<MealMatch> _mealMatches = new List<MealMatch>(); // Replace with your data source
        public List<(User User, MealMatch MealMatch)> MealMatches { get; set; } = new List<(User User, MealMatch MealMatch)>();
        public event Action OnMealMatchesChanged;
        private readonly UserDataService _userDataService;

        public MealMatchService(UserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task<MealMatch> GetMealMatchByIdAsync(long mealId)
        {
            return await Task.FromResult(_mealMatches.FirstOrDefault(m => m.Id == mealId));
        }

        public async Task<List<MealMatch>> GetMealMatches()
        {
            return await Task.FromResult(_mealMatches);
        }

        public async Task AddMealMatch(MealMatch meal)
        {
            _mealMatches.Add(meal);
            OnMealMatchesChanged?.Invoke();
        }

        public async Task MatchWithUser(long currentUserId, long mealId)
        {
            var meal = await GetMealMatchByIdAsync(mealId);

            if (meal == null)
            {
                // Meal not found, handle error
                return;
            }

            // Check if match already exists
            var existingMatch = MealMatches.FirstOrDefault(m => m.User.UserID == currentUserId && m.MealMatch.Id == mealId);

            if (existingMatch != default) // Check if existingMatch is not null
            {
                // Match already exists, handle accordingly (e.g., show a message)
                return;
            }

            // Get the user data
            var user = await _userDataService.GetUserByIdAsync(currentUserId);

            if (user == null)
            {
                // User not found, handle error
                return;
            }

            // Create and add the match
            MealMatches.Add((user, meal));

            // Notify listeners of the change
            OnMealMatchesChanged?.Invoke();
        }
        public async Task<List<(User User, MealMatch MealMatch)>> GetMealMatchesForUser(long userId)
        {
            var userMatches = MealMatches.Where(m => m.User.UserID == userId).ToList();

            return userMatches;
        }

        public async Task<List<(User User, MealMatch MealMatch)>> GetMealMatchesForMeal(long mealId)
        {
            var mealMatches = MealMatches.Where(m => m.MealMatch.Id == mealId).ToList();

            return mealMatches;
        }
    }
}