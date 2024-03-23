using MealApi.Models;
using MealApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MealRepositoryInMemory = MealApi.Models.Repositories.MealRepository.MealRepositoryInMemory;

namespace MealApi.Filters.ActionFilters;

public class MealValidateCreateMealFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Meal? meal = context.ActionArguments["meal"] as Meal;
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
            Meal? existingMeal = MealRepositoryInMemory.GetMealProperties(meal.Name, meal.KCal, meal.Country);
            if (existingMeal != null)
            {
                context.ModelState.AddModelError("Meal", $"{meal.Name} already exist");
                ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}