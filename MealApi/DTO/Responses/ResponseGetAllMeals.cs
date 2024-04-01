using MealApi.Models;

namespace MealApi.DTO.Responses;

public class ResponseGetAllMeals
{
    public List<ResponseGetMeal>? ListOfMeal {
        get;
        set;
    }
}