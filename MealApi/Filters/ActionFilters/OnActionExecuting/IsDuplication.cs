using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySqlConnector;

namespace MealApi.Filters.ActionFilters.OnActionExecuting;

public class IsDuplication : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        RequestCreateAMeal? meal = context.ActionArguments["meal"] as RequestCreateAMeal;
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
            QueryGetMeal query = new QueryGetMeal(dataSource, new RequestGetMeal
            {
                Name = meal.Name,
                KCal = meal.KCal,
                Country = meal.Country
            });
            ResponseGetMeal? response = query.GetMealAsync().Result;
            if (response != null)
            {
                context.ModelState.AddModelError("Meal", "This meal is already existe");
                ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}