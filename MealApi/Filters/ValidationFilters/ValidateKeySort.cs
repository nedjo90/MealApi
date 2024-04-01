using System.ComponentModel.DataAnnotations;
using MealApi.DTO.Requests;

namespace MealApi.Filters.ValidationFilters;

public class ValidateKeySort : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string key
            && !string.IsNullOrEmpty(key) 
            && !key.Equals("id", StringComparison.OrdinalIgnoreCase)
            && !key.Equals("kcal", StringComparison.OrdinalIgnoreCase)
            && !key.Equals("name", StringComparison.OrdinalIgnoreCase)
            && !key.Equals("country", StringComparison.OrdinalIgnoreCase)
            )
            return false;
        return true;
    }
}