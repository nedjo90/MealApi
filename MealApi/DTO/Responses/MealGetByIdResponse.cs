namespace MealApi.DTO.Responses;

public class MealGetByIdResponse
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public int? KCal { get; set; }
}