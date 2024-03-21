namespace MealApi.Models.Repositories;

public static partial class MealRepository
{
    public static void CreateMeal(Meal meal)
    {
        int maxId = _listOfMeal.Max(x => x.Id);
        meal.Id = maxId + 1;
        _listOfMeal.Add(meal);
    }
}