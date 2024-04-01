using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Models.Repositories.DbConfig;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlQuery;

public class QueryGetAllMeals : MyDbReader
{
    private string? _key;
    
    public QueryGetAllMeals(MySqlDataSource dataBase, RequestGetAllMeals? request) : base(dataBase)
    {
        _key = request?.Key;
        Query = $"SELECT * FROM meal_table ORDER BY ";
        if (request?.Key != null && !request.Key.Equals("id", StringComparison.CurrentCultureIgnoreCase))
        {
            Query += $"{request.Key}";
        }
        else
        {
            Query += "id";
        }
        if (request?.Sort != null && request.Sort == false)
            Query += " DESC";
    }
    
    public async Task<List<ResponseGetMeal>?> GetAllAsync()
    {
        await InitializeDbDataReader();
        if (Reader == null)
            return null;
        List<ResponseGetMeal> list = new List<ResponseGetMeal>();
        await using (Reader)
        {
            while (await Reader.ReadAsync())
            {
                ResponseGetMeal meal = new ResponseGetMeal()
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
    protected override void SanitizeQuery(){}
}