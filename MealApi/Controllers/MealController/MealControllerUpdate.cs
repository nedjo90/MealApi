using MealApi.Filters.ActionFilters;
using MealApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MealApi.Controllers.MealController;

public partial class MealController
{
    [HttpPut("{id}")]
    [Meal_ValidateMealIdFilter]
    [Meal_ValidateUpdateMealFilter]
    public IActionResult UpdateMeal(int id, Meal meal)
    {
        return NoContent();
    }
}