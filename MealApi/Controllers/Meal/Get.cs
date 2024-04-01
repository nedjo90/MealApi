using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Filters.ActionFilters.OnActionExecuting;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.Meal;

public partial class MealController
{
    [HttpGet("{id:int}")]
    [IsValidId]
    public async Task<IActionResult> GetMeal(
        [FromServices]
        MySqlDataSource db,
        int id
    )
    {
        QueryGetMeal query = new QueryGetMeal(db, new RequestGetMeal{ Id = id});
        ResponseGetMeal? response = await query.GetMealAsync();
        if (response == null)
            return NotFound();
        return Ok(response);
    }
   
    [HttpGet]
    public async Task<IActionResult> GetAllMealsAction([FromServices] MySqlDataSource db,[FromQuery] RequestGetAllMeals? request)
    {
        QueryGetAllMeals query = new QueryGetAllMeals(db, request);
        return Ok(await query.GetAllAsync());
    }
}