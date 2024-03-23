using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.DBConfig;

public class MyDbCommand : MyDbConnector
{
    protected MySqlCommand? Command;

    protected string? Query;

    protected MyDbCommand(MySqlDataSource dataBase) : base(dataBase)
    {
        Command = null;
        Query = null;
    }

    protected async Task InitializeCommand()
    {
        await CreateConnection();
        if (Connection != null)
        {
            Command = Connection.CreateCommand();
            Command.CommandText = Query;
        }
    }

    protected async Task<int> NonQueryAsync()
    {
        if (Command == null)
            return 0;
        return (await Command!.ExecuteNonQueryAsync());
    }
    
    protected async Task<object?> ScalarAsync()
    {
        if (Command == null)
            return null;
        return (await Command!.ExecuteScalarAsync());
    }
    
    protected async Task DisposeCommand()
    {
        if (Command != null)
            await Command.DisposeAsync();
        await DisposeConnection();
    }
}