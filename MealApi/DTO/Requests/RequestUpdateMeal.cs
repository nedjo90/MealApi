using System.ComponentModel.DataAnnotations;

namespace MealApi.DTO.Requests;

public class RequestUpdateMeal
{
    [Required]
    public int? Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int? KCal { get; set; }
    [Required]
    public string? Country { get; set;}
}