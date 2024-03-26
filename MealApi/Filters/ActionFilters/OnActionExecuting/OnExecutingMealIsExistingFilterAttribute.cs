using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.SqlQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySqlConnector;

namespace MealApi.Filters.ActionFilters.OnActionExecuting;

public class OnExecutingMealIsExistingFilterAttribute : ActionFilterAttribute
{
   public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
   {
      bool isValid = true;
      
      MySqlDataSource? data = context.ActionArguments["db"] as MySqlDataSource;
      RequestCreateAMeal? meal = context.ActionArguments["meal"] as RequestCreateAMeal;
      if (data == null)
      {
         isValid = false;
         context.ModelState.AddModelError("DataBase", "Fail to connect to the database");
         ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
         {
            Status = StatusCodes.Status500InternalServerError
         };
         context.Result = new BadRequestObjectResult(problemDetails);
      }
      else if (string.IsNullOrEmpty(meal?.Name)
               || string.IsNullOrEmpty(meal?.Country)
               || !meal.KCal.HasValue)
      {
         isValid = false;
         context.ModelState.AddModelError("Meal", "new meal data are invalid");
         ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
         {
            Status = StatusCodes.Status400BadRequest
         };
         context.Result = new BadRequestObjectResult(problemDetails);
      }
      else
      {
         QueryGetAMealBy query = new QueryGetAMealBy(data, meal.Name, (int)meal.KCal, meal.Country);
         ResponseGetAMeal? getAMeal = await query.GetByAsync();
         if (getAMeal != null)
         {
            isValid = false;
            Console.WriteLine(getAMeal);
            Console.WriteLine(getAMeal.ToString() + "hey");
            Console.WriteLine("id" + getAMeal.Id);
            context.ModelState.AddModelError("Meal", "meal already exist");
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
            {
               Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
         }
      }
      if (isValid)
      {
         await next();
      }
   }
}
