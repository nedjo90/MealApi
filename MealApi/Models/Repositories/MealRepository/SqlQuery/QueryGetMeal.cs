using MealApi.DTO.Requests;
using MealApi.DTO.Responses;
using MealApi.Models.Repositories.DbConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlQuery;

public class QueryGetMeal : MyDbReader
{
    private readonly RequestGetMeal _requestMeal;
    private bool _isValidQuery;

    public QueryGetMeal(MySqlDataSource dataBase, RequestGetMeal meal) : base(dataBase)
    {
        _requestMeal = meal;
        _isValidQuery = false;
    }

    private void BuildSqlQuery()
    {
        
        Query = $"SELECT * FROM meal_table WHERE ";
        if (_requestMeal.Id.HasValue && _requestMeal.Id > 0)
        {
            Query += $"`id` = @id ";
            _isValidQuery = true;
        }
        if (!string.IsNullOrEmpty(_requestMeal.Name))
        {
            if (_isValidQuery)
                Query += " AND ";
            Query += $"`name` = @name ";
            _isValidQuery = true;
        }
        if (_requestMeal.KCal.HasValue)
        {
            if (_isValidQuery)
                Query += " AND ";
            Query += $"`kcal` = @kcal ";
            _isValidQuery = true;
        }
        if (!string.IsNullOrEmpty(_requestMeal.Country))
        {
            if (_isValidQuery)
                Query += " AND ";
            Query += $"`country` = @country ";
            _isValidQuery = true;
        }

        Query += " LIMIT 1";
    }

    public async Task<ResponseGetMeal?> GetMealAsync()
    {
        BuildSqlQuery();
        if (_isValidQuery == false)
            return null;
        await InitializeDbDataReader();
        if (Reader == null)
            return null;
        await using (Reader)
        {
            if (!await Reader.ReadAsync())
                return null;
            ResponseGetMeal responseGetAMeal = new ResponseGetMeal
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
    protected override void SanitizeQuery()
    {
        if (_requestMeal.Id.HasValue && _requestMeal.Id != null)
            Command?.Parameters.AddWithValue("@id", _requestMeal.Id);
        if (!string.IsNullOrEmpty(_requestMeal.Name))
            Command?.Parameters.AddWithValue("@name", _requestMeal.Name);  
        if (_requestMeal.KCal.HasValue && _requestMeal.KCal != null)
            Command?.Parameters.AddWithValue("@kcal", _requestMeal.KCal);
        if (!string.IsNullOrEmpty(_requestMeal.Country))
            Command?.Parameters.AddWithValue("@country", _requestMeal.Country);
    }
}