namespace MealApi.Models.Repositories.MealRepository;

public static partial class MealRepositoryInMemory
{
    public static void CreateMeal(Meal meal)
    {
        int maxId = _listOfMeal.Max(x => x.Id);
        meal.Id = maxId + 1;
        _listOfMeal.Add(meal);
    }
}