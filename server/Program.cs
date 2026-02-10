var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

/*
* This minimal API is left in place to show that I know how they work.
*/
app.MapGet("/info", () =>
{
    var devName = new Info
    (
        "Frank",
        "Oud"
    );

    return devName;
})
.WithName("info");

app.Run();

record Info(string FirstName, string LastName)
{
    public string FullName => string.Concat(FirstName, " ", LastName);
}
