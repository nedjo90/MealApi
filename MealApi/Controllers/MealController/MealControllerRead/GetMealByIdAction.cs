using MealApi.Filters.ActionFilters;
using MealApi.Models.Repositories.MealRepository.SqlRequest;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetMealByIdAction : MealController
{
    [HttpGet("{id}")]
    [MealValidateMealIdFilter]
    public async Task<IActionResult?> GetMealById([FromServices] MySqlDataSource db,int id)
    {
        GetByIdSqlRequest meal = new GetByIdSqlRequest(db, id);
        return Ok(await meal.GetById());
    }
}