using server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

/*
* This minimal API is left in place to show that I know how they work.
*/
app.MapGet("minapi/info", () =>
{
    var devName = new Info
    (
        "Frank",
        "Oud"
    );

    return devName;
})
.WithName("info");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();