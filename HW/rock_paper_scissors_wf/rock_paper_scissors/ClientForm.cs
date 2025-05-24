using System.Net.Sockets;
using System.Text;

namespace rock_paper_scissors
{
    public partial class ClientForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public ClientForm()
        {
            InitializeComponent();
        }

        private async void ConnectToServer(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                try
                {
                    client = new TcpClient();
                    await client.ConnectAsync("127.0.0.1", 12345);
                    stream = client.GetStream();
                    UpdateStatus("Подключение успешно!");
                    sendMoveBtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Ошибка подключения: {ex.Message}");
                }
            }
        }

        private async void SendMove(object sender, EventArgs e)
        {
            if (stream != null && stream.CanWrite)
            {
                string move = moveCombo.SelectedItem.ToString();
                await GameLogic.SendMessageAsync(stream, move);

                string result = await GameLogic.ReadMessageAsync(stream);
                UpdateStatus(result);
            }
        }

        private void UpdateStatus(string message)
        {
            if (statusLog.InvokeRequired)
            {
                Invoke(new Action(() => statusLog.AppendText($"{DateTime.Now}: {message}\n")));
            }
            else
            {
                statusLog.AppendText($"{DateTime.Now}: {message}\n");
            }
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
