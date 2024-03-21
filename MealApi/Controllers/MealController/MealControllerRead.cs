using MealApi.Filters.ActionFilters;
using MealApi.Models;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealApi.Controllers.MealController;

public partial class MealController
{
    [HttpGet]
    public IActionResult GetAllMeals()
    {
        return Ok(MealRepository.GetAllMeals());
    }

    [HttpGet("SortByName")]
    [Meal_ValidateMealSortOrderFilter]
    public IActionResult GetAllMealsSortedByName([FromQuery] bool sort)
    {
        return Ok(MealRepository.GetSortedMealsByName(sort));
    }
    
    [HttpGet("SortByKCal")]
    [Meal_ValidateMealSortOrderFilter]
    public IActionResult GetAllMealsSortedByKCal([FromQuery] bool sort)
    {
        return Ok(MealRepository.GetSortedMealsByKCal(sort));
    }
    
    [HttpGet("SortByCountry")]
    [Meal_ValidateMealSortOrderFilter]
    public IActionResult GetAllMealsSortedByCountry([FromQuery] bool sort)
    {
        return Ok(MealRepository.GetSortedMealsByCountry(sort));
    }
    
    //Read
    [HttpGet("{id}")]
    [Meal_ValidateMealIdFilter]
    public IActionResult GetMealById(int id)
    {
        Meal? meal = MealRepository.GetMealById(id);
        if (meal == null)
            return NotFound();
        return Ok(meal);
    }
}