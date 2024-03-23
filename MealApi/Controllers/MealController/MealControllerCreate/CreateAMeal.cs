using MealApi.Controllers.MealController.MealControllerRead;
using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Filters.ActionFilters.OnActionExecuting;
using MealApi.Models;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerCreate;

public class CreateAMeal : MealController
{
    [HttpPost]
    //[OnExecutingCreateMealFilter]
    public async Task<IActionResult> CreateMeal([FromServices] MySqlDataSource db, RequestCreateAMeal newMeal)
    {
        var query = new QueryCreateAMeal(db, newMeal);
        var lastMeal = await query.CreateAMealAsync();
        if (lastMeal == null)
            return Problem();
        return CreatedAtAction("GetAMealByIdAction", "GetAMealById", new {id = lastMeal.Id}, lastMeal);
    }
}