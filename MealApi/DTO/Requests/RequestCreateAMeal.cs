using System.ComponentModel.DataAnnotations;

namespace MealApi.DTO.Requests;

public class RequestCreateAMeal
{
    public string? Name { get; set; }

    public int? KCal { get; set; }
    
    public string? Country { get; set;}
}