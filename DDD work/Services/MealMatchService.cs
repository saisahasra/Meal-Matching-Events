using DDD_work.Models;
using DDD_work.Models;


namespace DDD_work.Services.MealMatch

{
    public class MealMatchService
    {
        private List<Models.MealMatch> mealMatches = new List<Models.MealMatch>();

        public void AddMealMatch(int userId, string location, string visibility)
        {
            mealMatches.Add(new Models.MealMatch
            {
                Id = mealMatches.Count + 1,
                UserId = userId,
                Location = location,
                Visibility = visibility
            });
        }

        public List<Models.MealMatch> GetMealMatches(string visibility)
        {
            return mealMatches.FindAll(m => m.Visibility == visibility || visibility == "everyone");
        }
    }
}


