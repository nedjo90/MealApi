using Microsoft.AspNetCore.Mvc;

namespace MealApi.Models.Repositories;

public static partial class MealRepository 
{
    public static List<Meal> GetAllMeals()
    {
        return _listOfMeal;
    }

    public static Meal? GetMealById(int id)
    {
        return _listOfMeal.FirstOrDefault(x => x.Id == id);
    }
    
    public static List<Meal> GetSortedMealsByName(bool sort)
    {
        return sort ?  GetAllMealsByNameAsc() : GetAllMealsByNameDesc();
    }

    public static List<Meal> GetAllMealsByNameDesc()
    {
        List<Meal> descList = _listOfMeal.OrderByDescending(x => x.Name).ToList();
        return descList;
    }
    
    public static List<Meal> GetAllMealsByNameAsc()
    {
        List<Meal> ascList = _listOfMeal.OrderBy(x => x.Name).ToList();
        return ascList;
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
        List<Meal> listOfMeals = _listOfMeal.Where(x => x.Name == name).ToList();
        return listOfMeals;
    }
}