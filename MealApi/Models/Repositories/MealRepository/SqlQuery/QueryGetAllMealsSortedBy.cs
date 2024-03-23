using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlQuery;

public class QueryGetAllMealsSortedBy : QueryGetAllMeals
{
    public QueryGetAllMealsSortedBy(MySqlDataSource dataBase,string sortKey ,bool sort) : base(dataBase)
    {
        string order = sort ? "ASC" : "DESC";
        Query = $"SELECT * FROM meal_table ORDER BY {sortKey} {order}";
    }
}