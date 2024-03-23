using MealApi.Models;

namespace MealApi.DTO.Responses;

public class ResponseGetAllMeals
{
    public List<ResponseGetAMeal>? ListOfMeal {
        get;
        set;
    }
}