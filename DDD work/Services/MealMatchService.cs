

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD_work.Models;
using DDD_work.Data;
using Microsoft.EntityFrameworkCore;



namespace DDD_work.Services
{


    public class MealMatchService
    {
        private static List<MealMatch> _mealMatches = new List<MealMatch>
    {
        new MealMatch { Id = 1, Name = "Pasta Night", MealTime = DateTime.Now.AddHours(1), Description = "Delicious pasta with a side of garlic bread.", PosterUserId = 1, Visibility = VisibilityOption.Everyone },
        new MealMatch { Id = 2, Name = "Pizza Party", MealTime = DateTime.Now.AddHours(3), Description = "A fun pizza night for all! Bring your appetite!", PosterUserId = 2, Visibility = VisibilityOption.ConnectionsOnly },
    };

        public async Task<List<MealMatch>> GetMealMatches()
        {
            return await Task.FromResult(_mealMatches);
        }

        public async Task AddMealMatch(MealMatch newMeal)
        {
            newMeal.Id = _mealMatches.Count + 1; // Simulate auto-increment of Id
            _mealMatches.Add(newMeal);
            await Task.CompletedTask;
        }

        public async Task MatchWithUser(int userId, int mealId)
        {

            await Task.CompletedTask;
        }

        public async Task ConfirmUserAttendance(int userId, int mealId)
        {
            // Simulate attendance confirmation
            await Task.CompletedTask;
        }
    }

}


