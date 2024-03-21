using MealApi.Filters.ActionFilters;
using MealApi.Models;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealApi.Controllers.MealController;

public partial class MealController
{
    [HttpPost]
    [Meal_ValidateCreateMealFilter]
    public IActionResult CreateMeal(Meal meal)
    {
        MealRepository.CreateMeal(meal);
        return CreatedAtAction(nameof(GetMealById), new { Id = meal.Id }, meal);
    }
}