using System.Data;
using System.Data.Common;
using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlRequest;

public class GetByIdSqlRequest : MyDbReader 
{
    public GetByIdSqlRequest(MySqlDataSource dataBase, int id) : base(dataBase)
    {
        Query = $"SELECT * FROM meal_table WHERE id = {id}";
    }
    
    public async Task<MealGetByIdResponse?> GetById()
    {
        await InitializeDbDataReader();
        if (Reader == null)
            return null;
        await using (Reader)
        {
            if (!await Reader.ReadAsync())
                return null;
            MealGetByIdResponse meal = new MealGetByIdResponse
            {
                Id = Reader.GetInt32(0),
                Name = Reader.GetString(1),
                KCal = Reader.GetInt32(2),
                Country = Reader.GetString(3)
            };
            return meal;
        }
    }
}