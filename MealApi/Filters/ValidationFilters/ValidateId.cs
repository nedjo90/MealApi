using System.ComponentModel.DataAnnotations;

namespace MealApi.Filters.ValidationFilters;

public class ValidateId : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value != null && (int)value <= 0)
        {
            return false;
        }
        return true;
    }
}