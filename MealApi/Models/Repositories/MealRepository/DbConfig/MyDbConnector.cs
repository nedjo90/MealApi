using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.DBConfig;

public class MyDbConnector
{
    protected MySqlConnection? Connection;

    readonly MySqlDataSource? _dataBase;
    
    protected MyDbConnector(MySqlDataSource dataBase) 
    {
        _dataBase = dataBase;
        Connection = null;
    }

    protected async Task CreateConnection()
    {
        if (_dataBase != null)
            Connection = await _dataBase.OpenConnectionAsync();
    }

    protected async Task DisposeConnection()
    {
        if (Connection != null)
            await Connection.DisposeAsync();
    }

}