using MealApi.Models;

namespace MealApi.DTO.Responses;

public class MealGetAllResponse
{
    public List<Meal>? ListOfMeal {
        get;
        set;
    }
}