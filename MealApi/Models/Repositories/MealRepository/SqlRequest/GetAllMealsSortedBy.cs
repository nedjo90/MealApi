using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlRequest;

public class GetAllMealsSortedBy : GetAllMeals
{
    public GetAllMealsSortedBy(MySqlDataSource dataBase,string sortKey ,bool sort) : base(dataBase)
    {
        string order = sort ? "ASC" : "DESC";
        Query = $"SELECT * FROM meal_table ORDER BY {sortKey} {order}";
    }
}