using MealApi.Controllers.MealController.MealControllerRead;
using MealApi.Filters.ActionFilters;
using MealApi.Models;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using MealRepositoryInMemory = MealApi.Models.Repositories.MealRepository.MealRepositoryInMemory;

namespace MealApi.Controllers.MealController.MealControllerCreate;

public class CreateMealAction : MealController
{
    [HttpPost]
    [MealValidateCreateMealFilter]
    public IActionResult CreateMeal(Meal meal)
    {
        MealRepositoryInMemory.CreateMeal(meal);
        return CreatedAtAction("GetMealById", "GetMealByIdAction", new { id = meal.Id }, meal);
    }
}