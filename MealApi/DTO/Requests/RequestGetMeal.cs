using System.ComponentModel.DataAnnotations;
using MealApi.Filters.ValidationFilters;

namespace MealApi.DTO.Requests;

public class RequestGetMeal
{
    [ValidateId]
    public int? Id { get; set; }
    public string? Name { get; set; }
    public int? KCal { get; set; }
    public string? Country { get; set;}
}