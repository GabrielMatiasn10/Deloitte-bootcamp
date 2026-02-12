using Microsoft.EntityFrameworkCore;
using MinhaApi.Data; 
using StackExchange.Redis;
using MinhaApi.Queue;
using MinhaApi.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Registro do DbContext com Npgsql

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection"); 
    options
        .UseNpgsql(cs)
        .UseSnakeCaseNamingConvention();
});


// Recomendação do Npgsql para compatibilidade de timestamp (se aplicável)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();


// Redis ConnectionMultiplexer como Singleton
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var cs = builder.Configuration["Redis:ConnectionString"]!;
    return ConnectionMultiplexer.Connect(cs);
});


// Options da fila
builder.Services.Configure<RedisQueueOptions>(builder.Configuration.GetSection("Redis"));

// Producer (para enfileirar)
builder.Services.AddSingleton<ILoteQueueProducer, LoteQueueProducer>();

// Worker/Consumer (para processar)
builder.Services.AddHostedService<LoteQueueWorker>();

builder.Services.AddSingleton<LoteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Mapear controllers
app.MapControllers();

app.Run();