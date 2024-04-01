using MealApi.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MealApi.Filters.ActionFilters.OnActionExecuting;

public class IsValidMeal : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        RequestGetMeal? meal = context.ActionArguments["meal"] as RequestGetMeal;
        if (meal == null)
        {
            context.ModelState.AddModelError("Meal", "meal is null");
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
        else if (!meal.Id.HasValue
                 || !meal.KCal.HasValue
                 || string.IsNullOrEmpty(meal.Name)
                 || string.IsNullOrEmpty(meal.Country))
        {
            context.ModelState.AddModelError("Meal", "meal is invalid");
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
    }
}