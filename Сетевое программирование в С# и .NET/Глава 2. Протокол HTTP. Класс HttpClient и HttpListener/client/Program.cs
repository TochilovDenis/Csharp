// "http://localhost:5121/"

// Определение клиента

//using System.Net.Http.Json; // пространство имен метода GetFromJsonAsync

//class Program
//{
//    static HttpClient httpClient = new HttpClient();
//    static async Task Main()
//    {
//        object? data = await httpClient.GetFromJsonAsync("http://localhost:5121/", typeof(Person));
//        if (data is Person person)
//        {
//            Console.WriteLine($"Name: {person.Name}   Age: {person.Age}");
//        }
//    }
//}
//record Person(string Name, int Age);


// Метод ReadFromJsonAsync класса HttpContent
//using System.Net;
//using System.Net.Http.Json;
//class Program
//{
//    static HttpClient httpClient = new HttpClient();
//    static async Task Main()
//    {
//        using var response = await httpClient.GetAsync("http://localhost:5121/1");

//        if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
//        {
//            // получаем информацию об ошибке
//            Error? error = await response.Content.ReadFromJsonAsync<Error>();
//            Console.WriteLine(response.StatusCode);
//            Console.WriteLine(error?.Message);
//        }
//        else
//        {
//            // если запрос завершился успешно, получаем объект Person
//            Person? person = await response.Content.ReadFromJsonAsync<Person>();
//            Console.WriteLine($"Name: {person?.Name}   Age: {person?.Age}");
//        }
//    }
//}
//// для успешного ответа
//record Person(string Name, int Age);
//// для ошибок
//record Error(string Message);


// Отправка заголовков
// Глобальная установка заголовков для HttpClient

//class Program
//{
//    static HttpClient httpClient = new HttpClient();
//    static async Task Main()
//    {
//        // адрес сервера
//        var serverAddress = "http://localhost:5121/";
//        // устанавливаем оба заголовка
//        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla FIrefox 5.4");
//        httpClient.DefaultRequestHeaders.Add("SecreteCode", "hello");

//        using var response = await httpClient.GetAsync(serverAddress);
//        var responseText = await response.Content.ReadAsStringAsync();
//        Console.WriteLine(responseText);
//    }
//}


// Получение заголовков

// Представляет дату обращения
//class Program
//{
//    static HttpClient httpClient = new HttpClient();
//    static async Task Main()
//    {
//        var serverAddress = "http://localhost:5121/";
//        using var response = await httpClient.GetAsync(serverAddress);
//        var dateValues = response.Headers.GetValues("Date");

//        Console.WriteLine(dateValues.FirstOrDefault());
//    }
//}


// Отправка текста

class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        StringContent content = new StringContent("Tom");
        // определяем данные запроса
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5121/data");
        // установка отправляемого содержимого
        request.Content = content;
        // отправляем запрос
        using var response = await httpClient.SendAsync(request);
        // получаем ответ
        string responseText = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseText);
    }
}