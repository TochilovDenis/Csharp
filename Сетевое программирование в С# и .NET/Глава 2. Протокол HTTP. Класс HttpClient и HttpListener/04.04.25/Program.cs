
// Отправка запроса методом SendAsync

//class Program
//{
//    static HttpClient httpClient = new HttpClient();

//    static async Task Main()
//    {
//        // определяем данные запроса
//        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://www.google.com");

//        // получаем ответ
//        using HttpResponseMessage response = await httpClient.SendAsync(request);

//        // просматриваем данные ответа
//        // статус
//        Console.WriteLine($"Status: {response.StatusCode}\n");
//        //заголовки
//        Console.WriteLine("Headers");
//        foreach (var header in response.Headers)
//        {
//            Console.Write($"{header.Key}:");
//            foreach(var headerValue in header.Value)
//            {
//                Console.WriteLine(headerValue);
//            }
//        }
//        // содержимое ответа
//        Console.WriteLine("\nContent");
//        string content = await response.Content.ReadAsStringAsync();
//        Console.WriteLine(content);
//    }
//}

// -------------------------------------------------------------------------------------------------------

// GetAsync()

//class Program
//{
//    static HttpClient httpClient = new HttpClient();
//    static async Task Main()
//    {
//        // получаем ответ
//        using HttpResponseMessage response = await httpClient.GetAsync("https://www.google.com");
//        // получаем ответ
//        string content = await response.Content.ReadAsStringAsync();
//        Console.WriteLine(content);
//    }
//}


// -------------------------------------------------------------------------------------------------------



// GetStringAsync 
//class Program
//{
//    static HttpClient httpClient = new HttpClient();

//    static async Task Main()
//    {
//        string content = await httpClient.GetStringAsync("https://www.google.com");
//        Console.WriteLine(content);
//    }
//}

// GetByteArrayAsync 

//class Program
//{
//    static HttpClient httpClient = new HttpClient();

//    static async Task Main()
//    {
//        byte[] buffer = await httpClient.GetByteArrayAsync("https://www.google.com");
//        Console.WriteLine(System.Text.Encoding.UTF8.GetString(buffer));
//    }
//}

// GetStreamAsync
//class Program
//{
//    static HttpClient httpClient = new HttpClient();

//    static async Task Main()
//    {
//        using Stream stream = await httpClient.GetStreamAsync("https://www.google.com");
//        StreamReader reader = new StreamReader(stream);
//        string content = await reader.ReadToEndAsync();     // считываем поток в строку
//        Console.WriteLine(content);
//    }
//}