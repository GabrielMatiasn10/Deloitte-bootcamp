using Microsoft.EntityFrameworkCore;
using MinhaApi.Data; 
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Registro do DbContext com Npgsql

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection"); // ou "Postgres", conforme você padronizou
    options
        .UseNpgsql(cs)
        .UseSnakeCaseNamingConvention(); // <- esta linha resolve a conversão para snake_case
});


// Recomendação do Npgsql para compatibilidade de timestamp (se aplicável)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Mapear controllers
app.MapControllers();

app.Run();