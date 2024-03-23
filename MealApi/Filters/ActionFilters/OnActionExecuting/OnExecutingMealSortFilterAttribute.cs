using MealApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MealApi.Filters.ActionFilters.OnActionExecuting;

public class OnExecutingMealSortFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string? sortQuery = context.HttpContext.Request.Query["sort"];
        string? sortKeyQuery = context.HttpContext.Request.Query["sortKey"];
        bool isValidQuery = true;
        
        if (string.IsNullOrEmpty(sortQuery) 
            || !(sortQuery.Equals("true", StringComparison.CurrentCultureIgnoreCase)
                || sortQuery.Equals("false", StringComparison.CurrentCultureIgnoreCase))
            )
        {
            context.ModelState.AddModelError("Sort", $"Invalid sort method");
            isValidQuery = false;
        }
        if (string.IsNullOrEmpty(sortKeyQuery)
                 || !(sortKeyQuery.Equals("id", StringComparison.OrdinalIgnoreCase)
                    || sortKeyQuery.Equals("name", StringComparison.OrdinalIgnoreCase)
                    || sortKeyQuery.Equals("kcal", StringComparison.OrdinalIgnoreCase)
                    || sortKeyQuery.Equals("country", StringComparison.OrdinalIgnoreCase))
                 )
        {
            context.ModelState.AddModelError("SortKey", $"Sorting key is not valid");
            isValidQuery = false;
        }
        if (!isValidQuery)
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
    }
}