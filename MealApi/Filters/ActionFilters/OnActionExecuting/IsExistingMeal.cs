using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySqlConnector;

namespace MealApi.Filters.ActionFilters.OnActionExecuting;

public class IsExistingMeal : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        RequestUpdateMeal? meal = context.ActionArguments["meal"] as RequestUpdateMeal;
        MySqlDataSource dataSource = context.HttpContext.RequestServices.GetRequiredService<MySqlDataSource>();
        if (meal == null)
        {
            context.ModelState.AddModelError("Meal", "meal is null");
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
        else
        {
            QueryGetMeal query = new QueryGetMeal(dataSource, new RequestGetMeal() { Id = meal.Id });
            ResponseGetMeal? response = query.GetMealAsync().Result;
            if (response == null)
            {
                context.ModelState.AddModelError("Id", "Id is not existing");
                ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
