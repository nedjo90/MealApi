using MealApi.Filters.ActionFilters;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using MealRepositoryInMemory = MealApi.Models.Repositories.MealRepository.MealRepositoryInMemory;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetMealsByCountryAction : MealController
{
    [HttpGet("SortByCountry")]
    [MealValidateMealSortOrderFilter]
    public IActionResult GetAllMealsSortedByCountry([FromQuery] bool sort)
    {
        return Ok(MealRepositoryInMemory.GetSortedMealsByCountry(sort));
    }
}