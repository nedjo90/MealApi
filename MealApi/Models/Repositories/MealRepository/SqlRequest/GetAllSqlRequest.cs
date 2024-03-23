using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlRequest;

public class GetAllSqlRequest : MyDbReader
{
    public GetAllSqlRequest(MySqlDataSource dataBase) : base(dataBase)
    {
         Query = $"SELECT * FROM meal_table";
    }
    
    public async Task<List<Meal>?> GetAllAsync()
    {
        await InitializeDbDataReader();
        if (Reader == null)
            return null;
        List<Meal> list = new List<Meal>();
        await using (Reader)
        {
            while (await Reader.ReadAsync())
            {
                Meal meal = new Meal
                {
                    Id = Reader.GetInt32(0),
                    Name = Reader.GetString(1),
                    KCal = Reader.GetInt32(2),
                    Country = Reader.GetString(3)
                };
                list.Add(meal);
            }
        }
        return list;
    }
}