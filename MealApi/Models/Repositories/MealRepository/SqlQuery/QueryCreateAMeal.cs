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
        Query = $"INSERT INTO meal_table (name, kcal, country) VALUES ('{newMeal.Name}', {newMeal.KCal}, '{newMeal.Country}');" +
                $"SELECT LAST_INSERT_ID();";
    }

    public async Task<ResponseGetAMeal?> CreateAMealAsync()
    {
        await InitializeCommand();
        if (Command == null)
            return null;
        var id = await ScalarAsync();
        if (id == null)
            return null;
        _meal.Id = Convert.ToInt32(id.ToString());
        return _meal;
    }
}