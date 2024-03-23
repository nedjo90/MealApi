using MealApi.Filters.ActionFilters.OnActionExecuted;
using MealApi.Filters.ActionFilters.OnActionExecuting;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetAMealById : MealController
{
    [HttpGet("{id:int}")]
    [OnExecutedMealIdFilter]
    [OnExecutingMealIdFilter]
    public async Task<IActionResult> GetAMealByIdAction([FromServices]MySqlDataSource db,int id)
    {
        var query = new QueryGetAMealById(db, id);
        return Ok(await query.GetByIdAsync());
    }
}