using MealApi.Filters.ActionFilters.OnActionExecuted;
using MealApi.Models.Repositories.MealRepository.SqlRequest;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetAllMeals : MealController
{
    [HttpGet]
    public async Task<IActionResult> GetAllMealsAction([FromServices] MySqlDataSource db)
    {
        Models.Repositories.MealRepository.SqlRequest.GetAllMeals allMeals = new Models.Repositories.MealRepository.SqlRequest.GetAllMeals(db);
        var list = await allMeals.GetAllAsync();
        return Ok(list);
    }

}