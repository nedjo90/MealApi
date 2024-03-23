using MealApi.Filters.ActionFilters;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using MealRepositoryInMemory = MealApi.Models.Repositories.MealRepository.MealRepositoryInMemory;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetMealsByKCalAction : MealController
{
    [HttpGet("SortByKCal")]
    [MealValidateMealSortOrderFilter]
    public IActionResult GetAllMealsSortedByKCal([FromQuery] bool sort)
    {
        return Ok(MealRepositoryInMemory.GetSortedMealsByKCal(sort));
    }
}