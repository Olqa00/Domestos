using Domestos.Application;
using Domestos.Application.Products.Commands;
using Domestos.Application.Products.Queries;
using Domestos.Infrastructure;
using Domestos.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var persistence = builder.Configuration.GetValue<string>("Persistence");

switch (persistence)
{
    case "SqlServer" : builder.Services.AddSqlServer(builder.Configuration);
        break;
    case "PostgreSQL" : builder.Services.AddPostgreSQL(builder.Configuration);
        break;
    default: throw new Exception("No persistence set. Choose SqlServer or PostgreSQL persistence in application configuration");
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapPost("/products", async ([FromBody] CreateProduct command, [FromServices] IMediator mediator,
        CancellationToken cancellationToken = default) => await mediator.Send(command, cancellationToken))
    .WithName("Create")
    .WithOpenApi();

app.MapGet("/products", async ([FromServices] IMediator mediator,
CancellationToken cancellationToken = default) => await mediator.Send(new GetProducts(), cancellationToken))
.WithName("Get")
.WithOpenApi();

await app.RunAsync();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
