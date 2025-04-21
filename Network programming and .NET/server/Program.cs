using server_cns1;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 8888);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(iPEndPoint);
socket.Listen();

//Создание списка клиентов
List<Socket> sockets = new List<Socket>();

Dictionary<string, string> people = new Dictionary<string, string>();
/*
Console.WriteLine(JsonSerializer.Serialize(new Msg_t("list_client", "", people)));*/


Console.WriteLine("Сервер развернут по адресу:" + socket.LocalEndPoint);
Console.WriteLine("Ожидаем подключений");




while (true)
{

    Socket client = await socket.AcceptAsync();
   
    //Добавление нового клиента в список
    sockets.Add(client);

    teask_server(client);
}

async Task teask_server(Socket client)
{
    string name_client = "";
    string RemoteEP = client.RemoteEndPoint.ToString();


    try
    {
        while (true)
        {

            // буфер для накопления входящих данных
            var buffer = new List<byte>();

            // буфер для считывания одного байта
            var bytesRead = new byte[1];

            // считываем данные до конечного символа
            while (true)
            {
                var count = await client.ReceiveAsync(bytesRead, SocketFlags.None);
                // смотрим, если считанный байт представляет конечный символ, выходим
                if (count == 0 || bytesRead[0] == '\n') break;
                // иначе добавляем в буфер
                buffer.Add(bytesRead[0]);
            }

            string responseText = Encoding.UTF8.GetString(buffer.ToArray());

            Console.WriteLine("responseText:" + responseText);

            string resp_json = responseText.ToString();

            Msg_t? r_m_t = JsonSerializer.Deserialize<Msg_t>(resp_json);

            Console.WriteLine($"r_m_t.Command= {r_m_t.Command} -- r_m_t.Text= {r_m_t.Text}");


            if (r_m_t.Command.IndexOf("name") == 0)
            {
                name_client = r_m_t.Text;

                byte[] requestData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new Msg_t("add_client", name_client, "server" , null)) + '\n');

                if (!people.ContainsKey(RemoteEP))
                {
                    people.Add(RemoteEP, name_client);
                }
                else
                {
                    people[RemoteEP] = name_client;
                }

                await client.SendAsync(requestData, SocketFlags.None);

                Console.WriteLine("команда-имя");
            }
            else if (r_m_t.Command.IndexOf("get_clients") == 0)
            {
               
                byte[] requestData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new Msg_t("list_client", "", name_client , people))+'\n');

                await client.SendAsync(requestData, SocketFlags.None);

                Console.WriteLine("команда-пользователи");

            }
            else if (r_m_t.Command.IndexOf("file") == 0) // Команда для отправки файла
            {
                string path = @""; // путь к файлу картинки



            }
            else if (r_m_t.Command.IndexOf("msg") == 0)
            {

                byte[] requestData = Encoding.UTF8.GetBytes(resp_json + '\n');

                foreach (Socket socket in sockets)
                {
                    //sockets   =   [1,2,3]

                    if (socket != client)
                    {

                        await socket.SendAsync(requestData, SocketFlags.None);
                    }
                    else {
                        r_m_t.Command = "my_msg";
                        byte[] requestData2 = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(r_m_t) + '\n');
                        await socket.SendAsync(requestData2, SocketFlags.None);
                    }

                }

                Console.WriteLine(resp_json);
            }

        }
        Console.WriteLine($"Новый клиент - {name_client}  RemoteEP  -  {RemoteEP}");


    }
    catch (SocketException)
    {

        sockets.Remove(client);
        people.Remove(client.RemoteEndPoint.ToString());


        Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint} - {name_client}");
    }

}


