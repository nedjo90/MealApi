using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlQuery;

public class QueryGetAllMeals : MyDbReader
{
    public QueryGetAllMeals(MySqlDataSource dataBase) : base(dataBase)
    {
         Query = $"SELECT * FROM meal_table";
    }
    
    public async Task<List<ResponseGetAMeal>?> GetAllAsync()
    {
        await InitializeDbDataReader();
        if (Reader == null)
            return null;
        List<ResponseGetAMeal> list = new List<ResponseGetAMeal>();
        await using (Reader)
        {
            while (await Reader.ReadAsync())
            {
                ResponseGetAMeal meal = new ResponseGetAMeal()
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
    protected override void SanitizeQuery()
    {
    }
}