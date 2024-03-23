using MealApi.Models.Repositories.MealRepository.SqlRequest;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetAllMealsAction : MealController
{
    [HttpGet]
    public async Task<IActionResult> GetAllMeals([FromServices] MySqlDataSource db)
    {
        GetAllSqlRequest allSqlRequest = new GetAllSqlRequest(db);
        var list = await allSqlRequest.GetAllAsync();
        return Ok(list);
    }

}