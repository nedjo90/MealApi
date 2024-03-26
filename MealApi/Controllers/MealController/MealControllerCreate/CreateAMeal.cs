using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Filters.ActionFilters.OnActionExecuting;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Controllers.MealController.MealControllerCreate;

public class CreateAMeal : MealController
{
    [HttpPost]
    [OnExecutingValidateMealArgumentFilter]
    public async Task<IActionResult> CreateMeal([FromServices] MySqlDataSource db, RequestCreateAMeal meal)
    {
        try
        {
            var query = new QueryCreateAMeal(db, meal);
            int lastId = await query.CreateAMealAsync();
            Console.WriteLine(lastId);
            if (lastId != 0)
                return CreatedAtAction("GetAMealByIdAction", "GetAMealById", new {id = lastId}, new ResponseGetAMeal
                {
                    Id = lastId,
                    Name = meal.Name,
                    Country = meal.Country,
                    KCal = meal.KCal
                });
        }
        catch
        {
                return StatusCode(StatusCodes.Status500InternalServerError, meal);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}