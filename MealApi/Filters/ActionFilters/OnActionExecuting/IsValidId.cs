using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MealApi.Filters.ActionFilters.OnActionExecuting;

public class IsValidId : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? id = context.ActionArguments["id"] as int?;
        if (id == null || id <= 0)
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