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

    protected async Task InitializeQueryCommand()
    {
        await CreateConnection();
        if (Connection != null)
        {
            Command = Connection.CreateCommand();
            Command.CommandText = Query;
        }
    }
    protected async Task DisposeCommand()
    {
        if (Command != null)
            await Command.DisposeAsync();
        await DisposeConnection();
    }
}