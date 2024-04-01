namespace MealApi.DTO.Responses;

public class ResponseGetMeal
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public int? KCal { get; set; }
    
    public string? Country { get; set;}
}