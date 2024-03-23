namespace MealApi.Models.Repositories.MealRepository;

public static partial class MealRepositoryInMemory
{
    static List<Meal> _listOfMeal = new List<Meal>()
    {
        new Meal{Id = 1, Name = "Kebab", KCal = 500, Country = "Turkey"},
        new Meal{Id = 2, Name = "Pizza", KCal = 800, Country = "Italy"},
        new Meal{Id = 3, Name = "Sushi", KCal = 600, Country = "Japan"},
        new Meal{Id = 4, Name = "Burger", KCal = 700, Country = "USA"},
        new Meal{Id = 5, Name = "Curry", KCal = 600, Country = "India"},
        new Meal{Id = 6, Name = "Salad", KCal = 300, Country = "France"},
        new Meal{Id = 7, Name = "Pasta", KCal = 600, Country = "Italy"},
        new Meal{Id = 8, Name = "Steak", KCal = 800, Country = "Argentina"},
        new Meal{Id = 9, Name = "Fish and Chips", KCal = 900, Country = "UK"},
        new Meal{Id = 10, Name = "Sushi", KCal = 550, Country = "Japan"},
        new Meal{Id = 11, Name = "Tacos", KCal = 650, Country = "Mexico"},
        new Meal{Id = 12, Name = "Lasagna", KCal = 750, Country = "Italy"},
        new Meal{Id = 13, Name = "Soup", KCal = 400, Country = "France"},
        new Meal{Id = 14, Name = "Roast Chicken", KCal = 850, Country = "USA"},
        new Meal{Id = 15, Name = "Sandwich", KCal = 500, Country = "UK"},
        new Meal{Id = 16, Name = "Sushi", KCal = 700, Country = "Japan"},
        new Meal{Id = 17, Name = "Stir Fry", KCal = 550, Country = "China"},
        new Meal{Id = 18, Name = "Paella", KCal = 700, Country = "Spain"}
    };

    public static void DisplayListOfMeal(List<Meal> list)
    {
        foreach (Meal meal in list)
        {
            Console.WriteLine(
                $"{meal.Id} " +
                $"{meal.Name} " +
                $"`{meal.KCal} " +
                $"{meal.Country}"
                );
        }
    }
    
    public static bool MealExist(int? id = null)
    {
        return _listOfMeal.Any(x => x.Id == id);
    }
    
    public static bool MealNameExist(string? name = null)
    {
        return _listOfMeal.Any(x => x.Name == name);
    }
    
    public static bool MealKCalExist(int? kcal = null)
    {
        return _listOfMeal.Any(x => x.KCal == kcal);
    }
    
    public static bool MealKCalRangeExist(int minkcal)
    {
        return _listOfMeal.Any(x => x.KCal >= minkcal);
    }
    
    public static bool MealKCalRangeExist(int minkcal, int maxkcal)
    {
        return _listOfMeal.Any(x => x.KCal >= minkcal && x.KCal < maxkcal);
    }
    public static bool MealCountryExist(string? country = null)
    {
        return _listOfMeal.Any(x => x.Country == country);
    }

    public static Meal? GetMealProperties(string? name, int? kcal, string? country)
    {
        return _listOfMeal.FirstOrDefault(x => 
            !string.IsNullOrWhiteSpace(name) &&
            !string.IsNullOrWhiteSpace(x.Name) &&
            x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(country) &&
            !string.IsNullOrWhiteSpace(x.Country) &&
            x.Country.Equals(country, StringComparison.OrdinalIgnoreCase) &&
            kcal.HasValue && x.KCal.HasValue && kcal == x.KCal
        );
    }
}