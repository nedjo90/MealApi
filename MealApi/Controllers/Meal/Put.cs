using MealApi.DTO.Requests;
using MealApi.Filters.ActionFilters.OnActionExecuting;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.Meal;

public partial class MealController
{
    [HttpPut]
    //[IsValidMeal]
    [IsExistingMeal]
    public async Task<IActionResult> PutMeal([FromServices] MySqlDataSource db,[FromBody]RequestUpdateMeal meal)
    {
        QueryUpdateMeal qMeal = new QueryUpdateMeal(db, meal);
        await qMeal.UpdateAMealAsync();
        return NoContent();
    }
}