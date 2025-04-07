using System;
using System.Collections.Generic;
using DDD_work.Models;

public class MealMatchDataService
{
    public List<(User User, MealMatch MealMatch)> MealMatches { get; set; } = new List<(User User, MealMatch MealMatch)>();

    public event Action OnMealMatchesChanged;

    public void NotifyMealMatchesChanged()
    {
        OnMealMatchesChanged?.Invoke();
    }
}