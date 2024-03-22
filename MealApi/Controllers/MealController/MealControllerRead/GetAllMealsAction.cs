using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetAllMealsAction : MealController
{
    [HttpGet]
    public IActionResult GetAllMeals()
    {
        return Ok(MealRepository.GetAllMeals());
    }
}