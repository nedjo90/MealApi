using MealApi.Models;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MealApi.Filters.ActionFilters;

public class Meal_ValidateMealIdFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        //["id"] => c'est l'argument envoyé par la requête à la méthode action
        int? mealId = context.ActionArguments["id"] as int?;

        if (mealId.HasValue)
        {
            if (mealId <= 0)
            {
                context.ModelState.AddModelError("Id", "Id is invalid");
                ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else if (!MealRepository.MealExist(mealId))
            {
                context.ModelState.AddModelError("Id", "Id doesn't exist");
                ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound
                };
                context.Result = new NotFoundObjectResult(problemDetails);
            }
        }
    }
}