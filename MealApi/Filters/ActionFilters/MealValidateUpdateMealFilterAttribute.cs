using Microsoft.AspNetCore.Mvc.Filters;

namespace MealApi.Filters.ActionFilters;

public class MealValidateUpdateMealFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
    }
}