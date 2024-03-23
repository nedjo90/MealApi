using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlQuery;

public class QueryGetAMealById : MyDbReader 
{
    public QueryGetAMealById(MySqlDataSource dataBase, int id) : base(dataBase)
    {
        Query = $"SELECT * FROM meal_table WHERE id = {id}";
    }
    
    public async Task<ResponseGetAMeal?> GetByIdAsync()
    {
        await InitializeDbDataReader();
        if (Reader == null)
            return null;
        await using (Reader)
        {
            if (!await Reader.ReadAsync())
                return null;
            ResponseGetAMeal responseGetAMeal = new ResponseGetAMeal
            {
                Id = Reader.GetInt32(0),
                Name = Reader.GetString(1),
                KCal = Reader.GetInt32(2),
                Country = Reader.GetString(3)
            };
            await DisposeReader();
            return responseGetAMeal;
        }
    }
}