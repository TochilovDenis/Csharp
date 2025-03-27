using System.Net;
using System.Net.Sockets;
using System.Text;

IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 8888);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(iPEndPoint);
socket.Listen();

//Создание списка клиентов
List<Socket> sockets = new List<Socket>();

Dictionary<string, string> people = new Dictionary<string, string>();

Console.WriteLine("Сервер развернут по адресу:" + socket.LocalEndPoint);
Console.WriteLine("Ожидаем подключений");

while (true)
{

    Socket client = await socket.AcceptAsync();
    Console.WriteLine("Новый клиент " + client.RemoteEndPoint);
    //Добавление нового клиента в список
    sockets.Add(client);

    var task3 = teask_server(client);

}

async Task teask_server(Socket client)
{
    try
    {
        string name_client = "";

        while (true)
        {

            byte[] buffer = new byte[512];
            int bytes = 0;

            // получаем данные из потока
            bytes = await client.ReceiveAsync(buffer, SocketFlags.None);

            // считыванием массив байт в строку
            var responseText = Encoding.UTF8.GetString(buffer, 0, bytes);


            if (responseText == "время")
            {
                // считыванием строку в массив байт
                byte[] requestData = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());

                // отправляем данные
                await client.SendAsync(requestData, SocketFlags.None);

                Console.WriteLine("команда-время");
            }
            else if (responseText == "дата")
            {
                // считыванием строку в массив байт
                byte[] requestData = Encoding.UTF8.GetBytes(DateTime.Now.ToLongDateString());
                // отправляем данные
                await client.SendAsync(requestData, SocketFlags.None);
                Console.WriteLine("команда-дата");
            }
            else if (responseText.IndexOf("name:") == 0)
            {
                byte[] requestData = Encoding.UTF8.GetBytes("Имя пользователя:" + responseText.Substring(5));

                name_client = responseText.Substring(5);

                if (!people.ContainsKey(client.RemoteEndPoint.ToString()))
                {
                    people.Add(client.RemoteEndPoint.ToString(), responseText.Substring(5));
                }
                else
                {
                    people[client.RemoteEndPoint.ToString()] = responseText.Substring(5);
                }

                await client.SendAsync(requestData, SocketFlags.None);
                Console.WriteLine("команда-имя");
            }
            else if (responseText == "_names_")
            {
                string all_name_cln = "";
                foreach (var person in people)
                {
                    all_name_cln += $"key: {person.Key}  value: {person.Value}\n";
                }
                byte[] requestData = Encoding.UTF8.GetBytes(all_name_cln);
                await client.SendAsync(requestData, SocketFlags.None);
                Console.WriteLine("команда-пользователи");
            }
            else
            {
                // считыванием строку в массив байт

                byte[] requestData = Encoding.UTF8.GetBytes("Сообщение от -" + name_client + "-" + responseText);

                //byte[] requestData = Encoding.UTF8.GetBytes("Сообщение от -" + people[client.RemoteEndPoint.ToString()] + "-"+ responseText);

                //Отправка полученного сообщения (responseText) всем подключившимся клиентам/сокетам

                foreach (Socket socket in sockets)
                {
                    if (socket != client)
                    {
                        await socket.SendAsync(requestData, SocketFlags.None);
                    }
                }

                Console.WriteLine(responseText);
            }
        }
    }
    catch (SocketException)
    {
        Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint}");
    }
}







/*using System.Net;
using System.Net.Sockets;
using System.Text;

IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 8888);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(iPEndPoint);
socket.Listen();

//Создание списка клиентов
List<Socket> sockets = new List<Socket>();

Dictionary<string, string> people = new Dictionary<string, string>();

Console.WriteLine("Сервер развернут по адресу:" + socket.LocalEndPoint);
Console.WriteLine("Ожидаем подключений");

while (true)
{
   
    Socket client = await socket.AcceptAsync();
    Console.WriteLine("Новый клиент "+ client.RemoteEndPoint);
    //Добавление нового клиента в список
    sockets.Add(client);

    var task3 = teask_server(client);


}

async Task teask_server(Socket client)
{

    try
    {
        while (true)
        {

            byte[] buffer = new byte[512];
            int bytes = 0;

            // получаем данные из потока
            bytes = await client.ReceiveAsync(buffer, SocketFlags.None);

            // считыванием массив байт в строку
            var responseText = Encoding.UTF8.GetString(buffer, 0, bytes);


            if (responseText == "время")
            {
                // считыванием строку в массив байт
                byte[] requestData = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());

                // отправляем данные
                await client.SendAsync(requestData, SocketFlags.None);

                Console.WriteLine("команда-время");
            }
            else if (responseText == "дата")
            {
                // считыванием строку в массив байт
                byte[] requestData = Encoding.UTF8.GetBytes(DateTime.Now.ToLongDateString());
                // отправляем данные
                await client.SendAsync(requestData, SocketFlags.None);
                Console.WriteLine("команда-дата");
            }
            else if (responseText.IndexOf("name:")>=0)
            {
                // считыванием строку в массив байт
                people.Add(client.RemoteEndPoint.ToString(), responseText.Substring(5));
                byte[] requestData = Encoding.UTF8.GetBytes("имя:"+ responseText.Substring(5));
                // отправляем данные
                await client.SendAsync(requestData, SocketFlags.None);
                Console.WriteLine("команда-имя");
            }
            else
            {
                // считыванием строку в массив байт

                byte[] requestData = Encoding.UTF8.GetBytes("Сообщение от -" + people[client.RemoteEndPoint.ToString()] + "-"+ responseText);

                //Отправка полученного сообщения (responseText) всем подключившимся клиентам/сокетам

                foreach (Socket socket in sockets) {
                    if(socket != client) {
                        await socket.SendAsync(requestData, SocketFlags.None);
                    }
                }
                Console.WriteLine(responseText);
            }
        }
    }
    catch (SocketException)
    {
        Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint}");
    }
}
*/