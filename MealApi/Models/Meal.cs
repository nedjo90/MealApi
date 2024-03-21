using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MealApi.Models;

public class Meal
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string? Name { get; set; }

    [Required]
    public int? KCal { get; set; }

    [Required]
    [MinLength(2)]
    public string? Country { get; set; }
    
}