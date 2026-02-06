using Microsoft.EntityFrameworkCore;
using MinhaApi.Data; // Certifique-se que o namespace do seu AppDbContext é este

var builder = WebApplication.CreateBuilder(args);

// --- ADICIONE ESTAS LINHAS AQUI (FUNDAMENTAL) ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// ------------------------------------------------
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Importante: MapControllers deve estar aqui para o seu LotesMinerioController funcionar
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Se estiver dando erro de HTTPS no Docker/Console, você pode comentar a linha abaixo temporariamente
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}