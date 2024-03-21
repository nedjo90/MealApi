using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MealApi.Filters.ActionFilters;

public class Meal_ValidateMealSortOrderFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        bool? mealSort = context.ActionArguments["sort"] as bool?;
        if (mealSort == null)
        {
            context.ModelState.AddModelError("Sort", "Sort method is null");
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
        
    }
}