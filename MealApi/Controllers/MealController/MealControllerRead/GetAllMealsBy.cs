using MealApi.Filters.ActionFilters.OnActionExecuted;
using MealApi.Filters.ActionFilters.OnActionExecuting;
using MealApi.Models.Repositories.MealRepository.SqlRequest;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetAllMealsBy : MealController
{
    [OnExecutingMealSortFilter]
    [HttpGet]
    public async Task<IActionResult> GetMealsByCountryAction
        ([FromServices] MySqlDataSource db,[FromQuery]string sortKey,[FromQuery] bool sort)
    {
        var getAllMealsSortedByCountry = new GetAllMealsSortedBy(db, sortKey,sort);
        return Ok(await getAllMealsSortedByCountry.GetAllAsync());
    }
}