using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.DBConfig;

public abstract class MyDbCommand : MyDbConnector
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
            SanitizeQuery();
        }
    }

    protected abstract void SanitizeQuery();
    
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