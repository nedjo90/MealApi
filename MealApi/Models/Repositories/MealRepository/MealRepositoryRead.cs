namespace MealApi.Models.Repositories.MealRepository;

public static partial class MealRepositoryInMemory 
{
    public static List<Meal> GetAllMeals()
    {
        return _listOfMeal;
    }

    public static Meal? GetMealById(int id)
    {
        return _listOfMeal.FirstOrDefault(x => x.Id == id);
    }
    
    public static List<Meal> GetMealsByName(bool? sort = null, string? name = null)
    {
        List<Meal> listOfMeal = _listOfMeal;
        if (name != null)
            listOfMeal = _listOfMeal.FindAll(x => x.Name != null && x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (sort != null)
            return sort == true ?  GetAllMealsByNameAsc(listOfMeal) : GetAllMealsByNameDesc(listOfMeal);
        return listOfMeal;
    }

    public static List<Meal> GetAllMealsByNameDesc(List<Meal>? listOfMeal = null)
    {
        if (listOfMeal == null)
            return _listOfMeal.OrderByDescending(x => x.Name).ToList();
        return listOfMeal.OrderByDescending(x => x.Name).ToList();
    }
    
    public static List<Meal> GetAllMealsByNameAsc(List<Meal>? listOfMeal = null)
    {
        if (listOfMeal == null)
            return _listOfMeal.OrderBy(x => x.Name).ToList();
        return listOfMeal.OrderBy(x => x.Name).ToList();
    }

    public static List<Meal> GetSortedMealsByKCal(bool sort)
    {
        return sort ? GetAllMealsByKCalAsc() : GetAllMealsByKCalDesc() ;
    }
    public static List<Meal> GetAllMealsByKCalDesc()
    {
        List<Meal> ascList = _listOfMeal.OrderByDescending(x => x.KCal).ToList();
        return ascList;
    }
    
    public static List<Meal> GetAllMealsByKCalAsc()
    {
        List<Meal> ascList = _listOfMeal.OrderBy(x => x.KCal).ToList();
        return ascList;
    }
    
    public static List<Meal> GetSortedMealsByCountry(bool sort)
    {
        return sort ? GetAllMealsByCountryAsc() : GetAllMealsByCountryDesc() ;
    }
    public static List<Meal> GetAllMealsByCountryDesc()
    {
        List<Meal> ascList = _listOfMeal.OrderByDescending(x => x.Country).ToList();
        return ascList;
    }
    
    public static List<Meal> GetAllMealsByCountryAsc()
    {
        List<Meal> ascList = _listOfMeal.OrderBy(x => x.Country).ToList();
        return ascList;
    }

    public static List<Meal> GetMealsByName(string name)
    {
        List<Meal> listOfMeals = _listOfMeal.FindAll(x => x.Name == name);
        return listOfMeals;
    }
}