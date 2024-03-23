using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetAllMeals : MealController
{
    [HttpGet]
    public async Task<IActionResult> GetAllMealsAction([FromServices] MySqlDataSource db)
    {
        var query = new QueryGetAllMeals(db);
        return Ok(await query.GetAllAsync());
    }

}