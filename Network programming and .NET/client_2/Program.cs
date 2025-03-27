using System.Net.Sockets;
using System.Text;

Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

try
{
    await socket.ConnectAsync("127.0.0.1", 8888);

    var task_receive = receive_(socket);
    var task_send = send_(socket);

    await Task.WhenAll(task_receive, task_send);
}
catch (SocketException)
{
    Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint}");
}


async Task send_(Socket socket)
{
    try
    {
        while (true)
        {
            Console.WriteLine("Введите сообщение:");

            //Отправляем данные на сервер
            string msg = Console.ReadLine();

            // считыванием строку в массив байт
            byte[] requestData = Encoding.UTF8.GetBytes(msg);
            // отправляем данные
            await socket.SendAsync(requestData, SocketFlags.None);
        }
    }
    catch (SocketException)
    {
        Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint}");
    }
}


async Task receive_(Socket socket)
{
    try
    {
        while (true)
        {
            //Получаем данные от сервера
            byte[] buffer = new byte[512];

            // получаем данные из потока
            int bytes = await socket.ReceiveAsync(buffer, SocketFlags.None);

            // считыванием массив байт в строку
            var responseText = Encoding.UTF8.GetString(buffer, 0, bytes);

            Console.WriteLine("Ответ:" + responseText);

            Thread.Sleep(200);
        }
    }
    catch (SocketException)
    {
        Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint}");
    }
}
