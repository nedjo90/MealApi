using MealApi.DTO.Responses;
using MealApi.Models;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Meal = MealApi.Models.Meal;
using MealRepositoryInMemory = MealApi.Models.Repositories.MealRepository.MealRepositoryInMemory;

namespace MealApi.Filters.ActionFilters;

public class MealValidateMealIdFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        //["id"] => c'est l'argument envoyé par la requête à la méthode action
        int? mealId = context.ActionArguments["id"] as int?;

        if (mealId.HasValue && mealId <= 0)
        {
                context.ModelState.AddModelError("Id", "Id is invalid");
                ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
        }
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        
        if (context.Result == null)
        {
            context.ModelState.AddModelError("Id", "Id is not found");
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status404NotFound
            };
            context.Result = new NotFoundObjectResult(problemDetails);
        }
    }
}