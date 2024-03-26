using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlQuery;

public class QueryCreateAMeal : MyDbCommand
{
    ResponseGetAMeal _meal;
    public QueryCreateAMeal(MySqlDataSource dataBase, RequestCreateAMeal newMeal) : base(dataBase)
    {
        _meal = new ResponseGetAMeal
        {
            Name = newMeal.Name,
            KCal = newMeal.KCal,
            Country = newMeal.Country
        };
        Query = $"INSERT INTO meal_table (`name`, `kcal`, `country`) VALUES (@name, @kcal, @country); SELECT LAST_INSERT_ID();";
    }

    public async Task<int> CreateAMealAsync()
    {
        await InitializeCommand();
        if (Command == null)
            return 0;
        var id = await ScalarAsync();
        if (id == null || !int.TryParse(id.ToString(), out int newId))
            return 0;
        return newId;
    }
    
    protected override void SanitizeQuery()
    {
        Command?.Parameters.AddWithValue("@name", _meal.Name);
        Command?.Parameters.AddWithValue("@kcal", _meal.KCal);
        Command?.Parameters.AddWithValue("@country", _meal.Country);
    }
}