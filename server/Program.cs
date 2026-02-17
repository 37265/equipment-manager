using server.Models;
using server.Services;
using server.Interfaces;
using Microsoft.EntityFrameworkCore;

// ------------------------------------ Builder stuff ---------------------------------------------
// The builder adds all the necessary services and dependency injections before building the app

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Register the database context for Test; specifies that the context uses an in-memory DB
builder.Services.AddDbContext<TestContext>(options =>
    options.UseInMemoryDatabase("Test")
    .LogTo(Console.WriteLine, LogLevel.Information));

// Example of a dependency injection
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<TestContext>();

builder.Services.AddEndpointsApiExplorer();

// ------------------------------------- App stuff ------------------------------------------------
// Once the app is built, you can perform operations on it or tell it to use certain middleware.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
       options.DocumentPath = "/openapi/v1.json"; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();