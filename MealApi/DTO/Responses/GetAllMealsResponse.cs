using MealApi.Models;

namespace MealApi.DTO.Responses;

public class GetAllMealsResponse
{
    public List<GetAMealResponse>? ListOfMeal {
        get;
        set;
    }
}