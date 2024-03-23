using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MealApi.Filters.ActionFilters.OnActionExecuting;

public class OnExecutingMealIdFilterAttribute : ActionFilterAttribute
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
}