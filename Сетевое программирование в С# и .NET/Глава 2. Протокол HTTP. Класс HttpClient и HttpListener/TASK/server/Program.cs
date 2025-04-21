var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("/", () => new Person("Tom", 38));

app.Run();
record Person(string Name, int Age);