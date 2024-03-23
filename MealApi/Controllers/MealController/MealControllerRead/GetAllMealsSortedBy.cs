using MealApi.Filters.ActionFilters.OnActionExecuting;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetAllMealsSortedBy : MealController
{
    [OnExecutingMealSortFilter]
    [HttpGet]
    public async Task<IActionResult> GetMealsByCountryAction
        ([FromServices] MySqlDataSource db,[FromQuery]string sortKey,[FromQuery] bool sort)
    {
        var getAllMealsSortedByCountry = new QueryGetAllMealsSortedBy(db, sortKey,sort);
        return Ok(await getAllMealsSortedByCountry.GetAllAsync());
    }
}