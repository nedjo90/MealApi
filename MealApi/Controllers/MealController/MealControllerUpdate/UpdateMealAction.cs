using MealApi.Filters.ActionFilters;
using MealApi.Filters.ActionFilters.OnActionExecuted;
using MealApi.Filters.ActionFilters.OnActionExecuting;
using MealApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealApi.Controllers.MealController.MealControllerUpdate;

public class UpdateMealAction : MealController
{
    [HttpPut("{id}")]
    [OnExecutingMealIdFilter]
    [OnExecutingUpdateMealFilter]
    public IActionResult UpdateMeal(int id, Meal meal)
    {
        return NoContent();
    }
}