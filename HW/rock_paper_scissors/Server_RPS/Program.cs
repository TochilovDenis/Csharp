using System;
using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Server_RPS
{
    internal class Program
    {
        static void Main()
        {
            const int port = 12345;
            const int maxPlayers = 2;
            const int rounds = 5;

            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine("Сервер запущен. Ожидание подключений...");

            TcpClient[] clients = new TcpClient[maxPlayers];
            NetworkStream[] streams = new NetworkStream[maxPlayers];

            // Ждем подключения двух игроков
            for (int i = 0; i < maxPlayers; i++)
            {
                clients[i] = server.AcceptTcpClient();
                streams[i] = clients[i].GetStream();
                Console.WriteLine($"Игрок {i + 1} подключен");
            }

            PlayGame(streams, rounds);

            // Закрываем соединения
            foreach (var client in clients)
            {
                client.Close();
            }
            server.Stop();
        }

        static void PlayGame(NetworkStream[] streams, int rounds)
        {
            int[] scores = new int[2];

            for (int round = 1; round <= rounds; round++)
            {
                Console.WriteLine($"Раунд {round}");

                // Получение ходов от игроков
                string[] moves = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    moves[i] = ReadMessage(streams[i]);
                }

                // Определение победителя раунда
                int result = DetermineWinner(moves[0], moves[1]);

                // Отправка результатов игрокам
                for (int i = 0; i < 2; i++)
                {
                    string message = $"Раунд {round}:\n" +
                                    $"Игрок 1 выбрал {moves[0]}\n" +
                                    $"Игрок 2 выбрал {moves[1]}\n";

                    if (result == 0)
                    {
                        message += "Ничья\n";
                    }
                    else if (result == i + 1)
                    {
                        message += "Вы победили!\n";
                        scores[i]++;
                    }
                    else
                    {
                        message += "Проигрыш\n";
                    }

                    SendMessage(streams[i], message);
                }
            }

            // Объявление победителя игры
            string finalResult = "Итоговый результат:\n" +
                                $"Игрок 1: {scores[0]}\n" +
                                $"Игрок 2: {scores[1]}\n";

            if (scores[0] > scores[1])
            {
                finalResult += "Победил Игрок 1!";
            }
            else if (scores[0] < scores[1])
            {
                finalResult += "Победил Игрок 2!";
            }
            else
            {
                finalResult += "Ничья!";
            }

            for (int i = 0; i < 2; i++)
            {
                SendMessage(streams[i], finalResult);
            }
        }

        static string ReadMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

        static void SendMessage(NetworkStream stream, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        static int DetermineWinner(string move1, string move2)
        {
            if (move1 == move2) return 0; // Ничья

            if ((move1 == "Камень" && (move2 == "Ножницы" || move2 == "Ящерица")) ||
               (move1 == "Ножницы" && (move2 == "Бумага" || move2 == "Ящерица")) ||
               (move1 == "Бумага" && (move2 == "Камень" || move2 == "Спок")) ||
               (move1 == "Ящерица" && (move2 == "Спок" || move2 == "Бумага")) ||
               (move1 == "Спок" && (move2 == "Ножницы" || move2 == "Камень")))
            {
                return 1; // Побеждает первый игрок
            }
            return 2; // Побеждает второй игрок
        }
    }
}
