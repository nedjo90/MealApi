using MealApi.Controllers.MealController.MealControllerRead;
using MealApi.Filters.ActionFilters;
using MealApi.Models;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealApi.Controllers.MealController.MealControllerCreate;

public class CreateMealAction : MealController
{
    [HttpPost]
    [Meal_ValidateCreateMealFilter]
    public IActionResult CreateMeal(Meal meal)
    {
        MealRepository.CreateMeal(meal);
        return CreatedAtAction("GetMealById", "GetMealByIdAction", new { id = meal.Id }, meal);
    }
}