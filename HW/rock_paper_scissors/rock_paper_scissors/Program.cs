using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace rock_paper_scissors
{
    internal class Program
    {
        static void Main()
        {
            const string serverAddress = "127.0.0.1";
            const int port = 12345;

            TcpClient client = new TcpClient();
            try
            {
                Console.WriteLine("Подключение к серверу...");
                client.Connect(IPAddress.Parse(serverAddress), port);
                Console.WriteLine("Подключение успешно!");

                NetworkStream stream = client.GetStream();

                PlayGame(stream);

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void PlayGame(NetworkStream stream)
        {
            for (int round = 1; round <= 5; round++)
            {
                Console.WriteLine($"Ваш ход (Камень/Ножницы/Бумага/Ящерица/Спок):");
                string move = Console.ReadLine();

                // Отправка хода на сервер
                SendMessage(stream, move);

                // Получение результата раунда
                string result = ReadMessage(stream);
                Console.WriteLine(result);
            }

            // Получение итогового результата
            string finalResult = ReadMessage(stream);
            Console.WriteLine(finalResult);
        }

        static void SendMessage(NetworkStream stream, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        static string ReadMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

    }
}
