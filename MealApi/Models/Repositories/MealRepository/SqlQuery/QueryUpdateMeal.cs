using MealApi.DTO.Requests;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlQuery;

public class QueryUpdateMeal : MyDbCommand
{
    private RequestUpdateMeal _meal;
    
    public QueryUpdateMeal(MySqlDataSource dataBase, RequestUpdateMeal meal) : base(dataBase)
    {
        _meal = meal;
        Query = $"UPDATE meal_table SET `name` = @name, `kcal` = @kcal, `country` = @country WHERE `id` = @id LIMIT 1";
    }
    
    public async Task<int> UpdateAMealAsync()
    {
        await InitializeCommand();
        if (Command == null)
            return 0;
        Console.WriteLine("you're here");
        int? row = await Command?.ExecuteNonQueryAsync()!;
        return (row ?? 0);
    }

    protected override void SanitizeQuery()
    {
        Command?.Parameters.AddWithValue("@name", _meal.Name);
        Command?.Parameters.AddWithValue("@kcal", _meal.KCal);
        Command?.Parameters.AddWithValue("@country", _meal.Country);
        Command?.Parameters.AddWithValue("@id", _meal.Id);
    }
}