using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OrderApi.src.Application.Interfaces;
using OrderApi.src.Application.Services;
using OrderApi.src.Infrastructure.Repositories;
using OrderApi.src.Infrastructure;
using OrderApi.src.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var connection = new SqliteConnection(
    "Data Source=:memory:"
);

connection.Open();

builder.Services.AddSingleton(connection);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(connection);
});

builder.Services.AddScoped<IOrderApplicationService, OrderApplicationService>();
builder.Services.AddScoped<IItemApplicationService, ItemApplicationService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
