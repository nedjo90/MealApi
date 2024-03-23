using System.Data;
using System.Data.Common;
using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlRequest;

public class GetAMealById : MyDbReader 
{
    public GetAMealById(MySqlDataSource dataBase, int id) : base(dataBase)
    {
        Query = $"SELECT * FROM meal_table WHERE id = {id}";
    }
    
    public async Task<GetAMealResponse?> GetById()
    {
        await InitializeDbDataReader();
        if (Reader == null)
            return null;
        await using (Reader)
        {
            if (!await Reader.ReadAsync())
                return null;
            GetAMealResponse getAMeal = new GetAMealResponse
            {
                Id = Reader.GetInt32(0),
                Name = Reader.GetString(1),
                KCal = Reader.GetInt32(2),
                Country = Reader.GetString(3)
            };
            await DisposeReader();
            return getAMeal;
        }
    }
}