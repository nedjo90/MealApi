using System.Data.Common;
using MealApi.Models.Repositories.MealRepository.DBConfig;
using MySqlConnector;

namespace MealApi.Models.Repositories.DbConfig;

public abstract class MyDbReader : MyDbCommand
{
    protected DbDataReader? Reader;
    protected MyDbReader(MySqlDataSource dataBase) : base(dataBase)
    {
    }

    protected async Task InitializeDbDataReader()
    {
        await InitializeCommand();
        if (Command != null && !string.IsNullOrEmpty(Query))
            Reader = await Command.ExecuteReaderAsync();
    }

    protected async Task DisposeReader()
    {
        if (Reader != null)
            await Reader.DisposeAsync();
        await DisposeCommand();
    }
}