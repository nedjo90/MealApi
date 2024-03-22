using MealApi.Filters.ActionFilters;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetMealsByCountryAction : MealController
{
    [HttpGet("SortByCountry")]
    [MealValidateMealSortOrderFilter]
    public IActionResult GetAllMealsSortedByCountry([FromQuery] bool sort)
    {
        return Ok(MealRepository.GetSortedMealsByCountry(sort));
    }
}