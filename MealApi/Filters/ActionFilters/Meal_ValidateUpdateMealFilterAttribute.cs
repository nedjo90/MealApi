using Microsoft.AspNetCore.Mvc.Filters;

namespace MealApi.Filters.ActionFilters;

public class Meal_ValidateUpdateMealFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
    }
}