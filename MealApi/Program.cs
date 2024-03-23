using MySqlConnector;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// builder.Services.AddSwaggerGen();
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);


WebApplication app = builder.Build();

//app.UseHttpsRedirection();
// app.UseSwagger();
// app.UseSwaggerUI();

app.MapControllers();

app.Run();