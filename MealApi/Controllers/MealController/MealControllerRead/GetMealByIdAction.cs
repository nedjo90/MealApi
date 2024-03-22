using MealApi.DTO.Responses;
using MealApi.Filters.ActionFilters;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerRead;

public class GetMealByIdAction : MealController
{
    [HttpGet("{id:int}")]
    [Meal_ValidateMealIdFilter]
    public async Task<IActionResult> GetMealById([FromServices] MySqlDataSource db,int id)
    {
        MealTestMySql repository = new MealTestMySql(db);
        MealGetByIdResponse? result = await repository.FindOneAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}