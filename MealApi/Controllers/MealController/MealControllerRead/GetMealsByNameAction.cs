using MealApi.Models;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetMealsByNameAction : MealController
{
    [HttpGet("SortByName")]
    //[Meal_ValidateMealSortOrderFilter]
    public IActionResult GetAllMealsSortedByName([FromQuery] bool? sort, [FromQuery] string? name)
    {
        List<Meal> list = MealRepository.GetMealsByName(sort, name);
        return Ok(list);
    }
}