using MealApi.DTO.Responses;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.SqlQuery;

public class QueryGetAMealBy : MyDbReader
{
    ResponseGetAMeal _meal;
    
    public QueryGetAMealBy(MySqlDataSource dataBase, int id) : base(dataBase)
    {
        _meal = new ResponseGetAMeal{Id = id};
        Query = @"SELECT * FROM meal_table WHERE id = @id";
        Console.WriteLine(Query);
    }
    
    
    public QueryGetAMealBy(MySqlDataSource dataBase, string name, int kcal, string country) : base(dataBase)
    {
        _meal = new ResponseGetAMeal{Name = name, KCal = kcal, Country = country};
        Query = $"SELECT * FROM meal_table " +
                $"WHERE `name` = @name " +
                $"AND `kcal` = @kcal " +
                $"AND `country` = @country";
        Console.WriteLine(Query);
    }
    
    public async Task<ResponseGetAMeal?> GetByAsync()
    {
        Console.WriteLine(Query);
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
    protected override void SanitizeQuery()
    {
        if (_meal.Id.HasValue)
            Command?.Parameters.AddWithValue("@id", _meal.Id);
        else if (!string.IsNullOrEmpty(_meal.Name)
                 && !string.IsNullOrEmpty(_meal.Country)
                 && _meal.KCal.HasValue)
        {
            Command?.Parameters.AddWithValue("@name", _meal.Name); 
            Command?.Parameters.AddWithValue("@kcal", _meal.KCal); 
            Command?.Parameters.AddWithValue("@country", _meal.Country);
        }
    }
}