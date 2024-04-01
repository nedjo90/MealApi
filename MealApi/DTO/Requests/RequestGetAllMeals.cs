using System.ComponentModel.DataAnnotations;
using MealApi.Filters.ValidationFilters;

namespace MealApi.DTO.Requests;

public class RequestGetAllMeals
{
    
    [ValidateKeySort]
    public string? Key { get; set; }
    public bool? Sort { get; set; }
}