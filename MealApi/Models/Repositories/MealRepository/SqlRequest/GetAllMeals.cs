using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlRequest;

public class GetAllMeals : MyDbReader
{
    public GetAllMeals(MySqlDataSource dataBase) : base(dataBase)
    {
         Query = $"SELECT * FROM meal_table";
    }
    
    public async Task<List<GetAMealResponse>?> GetAllAsync()
    {
        await InitializeDbDataReader();
        if (Reader == null)
            return null;
        List<GetAMealResponse> list = new List<GetAMealResponse>();
        await using (Reader)
        {
            while (await Reader.ReadAsync())
            {
                GetAMealResponse meal = new GetAMealResponse()
                {
                    Id = Reader.GetInt32(0),
                    Name = Reader.GetString(1),
                    KCal = Reader.GetInt32(2),
                    Country = Reader.GetString(3)
                };
                list.Add(meal);
            }
        }
        await DisposeReader();
        return list;
    }
}