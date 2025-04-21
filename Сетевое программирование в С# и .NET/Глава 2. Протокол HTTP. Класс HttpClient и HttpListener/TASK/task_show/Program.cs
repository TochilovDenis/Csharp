
/*Создайте оконное приложение,которое по нажатию на кнопку загружает текст Гамлета Шекспира из https://www.gutenberg.org/.
 Когда текст загружен, его нужно отобразить в приложении. https://www.gutenberg.org/ — Проект Гуттенберга. 
Библиотека, в которой более 60000 бесплатных электронных книг.
 
 */
class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        StringContent content = new StringContent("Plain Text UTF-8");
        // определяем данные запроса
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://www.gutenberg.org/cache/epub/84/pg84.txt");
        // установка отправляемого содержимого
        request.Content = content;
        // отправляем запрос
        using var response = await httpClient.SendAsync(request);
        // получаем ответ
        string responseText = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseText);
    }
}