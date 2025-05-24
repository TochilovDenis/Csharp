using System.Net.Sockets;
using System.Net;
using System.Text;

namespace rock_paper_scissors_s
{
    public partial class ServerForm : Form
    {
        private bool isRunning = false;
        private TcpListener server;
        private TcpClient[] clients;
        private NetworkStream[] streams;

        public ServerForm()
        {
            InitializeComponent();
        }

        private async void StartServer(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                const int port = 12345;
                const int maxPlayers = 2;

                server = new TcpListener(IPAddress.Any, port);
                clients = new TcpClient[maxPlayers];
                streams = new NetworkStream[maxPlayers];

                try
                {
                    server.Start();
                    UpdateStatus("Сервер запущен. Ожидание подключений...");

                    // Ждем подключения двух игроков
                    for (int i = 0; i < maxPlayers; i++)
                    {
                        clients[i] = await server.AcceptTcpClientAsync();
                        streams[i] = clients[i].GetStream();
                        UpdateStatus($"Игрок {i + 1} подключен");
                    }

                    await PlayGame(streams);
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Ошибка: {ex.Message}");
                }
            }
        }

        private async Task PlayGame(NetworkStream[] streams)
        {
            const int rounds = 5;
            int[] scores = new int[2];

            for (int round = 1; round <= rounds; round++)
            {
                UpdateStatus($"Раунд {round}");

                // Получение ходов от игроков
                string[] moves = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    moves[i] = await ReadMessageAsync(streams[i]);
                }

                // Определение победителя раунда
                int result = GameLogic.DetermineWinner(moves[0], moves[1]);

                // Отправка результатов игрокам
                for (int i = 0; i < 2; i++)
                {
                    string message = $"Раунд {round}:\n" +
                                    $"Игрок 1 выбрал {moves[0]}\n" +
                                    $"Игрок 2 выбрал {moves[1]}\n";

                    if (result == 0)
                    {
                        message += "Ничья";
                    }
                    else if (result == i + 1)
                    {
                        message += "Вы победили!";
                        scores[i]++;
                    }
                    else
                    {
                        message += "Проигрыш!";
                    }

                    await SendMessageAsync(streams[i], message);
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

            foreach (var stream in streams)
            {
                await SendMessageAsync(stream, finalResult);
            }
        }

        private async Task<string> ReadMessageAsync(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

        private async Task SendMessageAsync(NetworkStream stream, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(data, 0, data.Length);
        }

        private void UpdateStatus(string message)
        {
            if (statusLog.InvokeRequired)
            {
                Invoke(new Action(() =>
                    statusLog.AppendText($"{DateTime.Now}: {message}\n")));
            }
            else
            {
                statusLog.AppendText($"{DateTime.Now}: {message}\n");
            }
        }

        public static class GameLogic
        {
            public static async Task<string> ReadMessageAsync(NetworkStream stream)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }

            public static async Task SendMessageAsync(NetworkStream stream, string message)
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);
            }

            public static int DetermineWinner(string move1, string move2)
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
}
