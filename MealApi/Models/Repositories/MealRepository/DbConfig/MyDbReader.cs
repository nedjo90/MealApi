using System.Data;
using System.Data.Common;
using MySqlConnector;

namespace MealApi.Models.Repositories.MealRepository.DBConfig;

public abstract class MyDbReader : MyDbCommand
{
    protected DbDataReader? Reader;

    protected MyDbReader(MySqlDataSource dataBase) : base(dataBase)
    {
        Reader = null;
    }

    protected async Task InitializeDbDataReader()
    {
        await InitializeQueryCommand();
        if (Command != null && !string.IsNullOrEmpty(Query))
            Reader = await Command.ExecuteReaderAsync();
    }
}