using System.Data;
using System.Data.Common;
using MealApi.DTO.Responses;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MealApi.Models.Repositories;

public class MealTestMySql(MySqlDataSource database)
{
    public async Task<MealGetByIdResponse?> FindOneAsync(int id)
    {
        await using MySqlConnection connection = await database.OpenConnectionAsync();
        string query = $"SELECT * FROM meal_table WHERE id = {id}";
        DataTable dataTable = new DataTable();
        await using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                adapter.Fill(dataTable);
        MealGetByIdResponse resp = new MealGetByIdResponse
        {
            Id = Convert.ToInt32(dataTable.Rows[0]["id"]),
            Name = Convert.ToString(dataTable.Rows[0]["name"]),
            KCal = Convert.ToInt32(dataTable.Rows[0]["kcal"])
        };
        return resp;
    }
}