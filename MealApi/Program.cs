WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

//app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();