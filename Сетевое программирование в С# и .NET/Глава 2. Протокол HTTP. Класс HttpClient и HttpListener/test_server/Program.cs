//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Определение сервера
//app.MapGet("/", () => new Person("Tom", 38));

// Метод ReadFromJsonAsync класса HttpContent
//app.MapGet("/{id?}", (int? id) =>
//{
//    if (id is null)
//        return Results.BadRequest(new { Message = "Некорректные данные в запросе" });
//    else if (id != 1)
//        return Results.NotFound(new { Message = $"Объект с id={id} не существует" });
//    else
//        return Results.Json(new Person("Bob", 42));
//});

//app.Run();

//record Person(string Name, int Age);


// Отправка заголовков
// Глобальная установка заголовков для HttpClient

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();


//app.MapGet("/", (HttpContext context) =>
//{
//    // пытаемся получить заголовок "SecreteCode"
//    context.Request.Headers.TryGetValue("User-Agent", out var userAgent);
//    // пытаемся получить заголовок "SecreteCode"
//    context.Request.Headers.TryGetValue("SecreteCode", out var secreteCode);
//    // отправляем данные обратно клиенту
//    return $"User-Agent: {userAgent}    SecreteCode: {secreteCode}";
//});

//app.Run();


// Отправка текста

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapPost("/data", async (HttpContext httpContext) =>
{
    using StreamReader reader = new StreamReader(httpContext.Request.Body);
    string name = await reader.ReadToEndAsync();
    return $"Получены данные: {name}";
});

app.Run();

