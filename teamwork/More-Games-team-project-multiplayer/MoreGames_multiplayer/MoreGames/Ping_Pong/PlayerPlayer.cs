using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using System.Xml.Linq;

namespace Ping_Pong
{
    public partial class PlayerPlayer : Form
    {
        // Контакт
        public Socket socket;

        // Игровые параметры
        private Random rand = new Random();                   // Генератор случайных чисел
        private bool goUp;                                    // Флаг движения игрока вверх
        private bool goDown;                                  // Флаг движения игрока вниз

        private bool goUpPlayer2;                             // Флаг движения второй ракетки вверх
        private bool goDownPlayer2;                           // Флаг движения второй ракетки вниз

        // Скоростные характеристики        
        private const int DEFAULT_SPEED = 5;                  // Базовая скорость мяча
        private int speed = DEFAULT_SPEED;                    // Текущая скорость мяча
        private int ballX = 5;                                // Горизонтальная компонента скорости мяча
        private int ballY = 5;                                // Вертикальная компонента скорости мяча

        private string _name = "";
        private string _name2 = "";


        // Система подсчета очков
        int playerScore_1 = 0;    // Очки игрока
        int playerScore_2 = 0;    // Очки компьютера

        int playerSpeed = 8;                                 // Скорость движения игрока

        // Массивы для случайной генерации скоростей
        int[] i = { 5, 6, 8, 9 };                            // Варианты горизонтальной скорости мяча
        int[] j = { 10, 9, 8, 11, 12 };                      // Варианты вертикальной скорости мяча

        public PlayerPlayer()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        // Обработчик нажатия клавиш управления
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            // Управление первой ракеткой
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;                                  // Активация движения вверх
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;                                // Активация движения вниз
            }

            // Управление второй ракеткой
            if (e.KeyCode == Keys.W)
            {
                goUpPlayer2 = true;
            }
            if (e.KeyCode == Keys.S)
            {
                goDownPlayer2 = true;
            }
        }

        // Обработчик отпускания клавиш управления
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            // Управление первой ракеткой
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;                                 // Деактивация движения вверх
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;                               // Деактивация движения вниз
            }

            // Управление второй ракеткой
            if (e.KeyCode == Keys.W)
            {
                goUpPlayer2 = false;
            }
            if (e.KeyCode == Keys.S)
            {
                goDownPlayer2 = false;
            }
        }

        // Основной игровой тикер
        private void timerTick(object sender, EventArgs e)
        {
            // Обновление позиции мяча
            ball.Top -= ballY;
            ball.Left -= ballX;

            // Обновление отображения счета
            player_score_1.Text = _name + ":" + playerScore_1;             // Отображение очков первого игрока
            player_score_2.Text = _name2 + ": " + playerScore_2;            // Отображение очков второго компьютера

         
            // Обработка столкновений со стенами
            if (ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
            {
                ballY = -ballY;                               // Отражение от верхней и нижней стены
            }

            // Проверка гола второго игрока
            if (ball.Left < -2)
            {
                ball.Left = 300;
                ballX = -ballX;
                playerScore_2++;                             // Очки второго игрока
            }

            // Проверка гола первого игрока
            if (ball.Right > this.ClientSize.Width + 2)
            {
                ball.Left = 300;
                ballX = -ballX;
                playerScore_1++;                               // Очки первого игрока
            }


            // Управление ракетками
            // Первая ракетка
            if (goDown && player_1.Top + player_1.Height < this.ClientSize.Height)
            {
                player_1.Top += playerSpeed;
            }
            if (goUp && player_1.Top > 0)
            {
                player_1.Top -= playerSpeed;
            }

            // Вторая ракетка
            if (goDownPlayer2 && player_2.Top + player_2.Height < this.ClientSize.Height)
            {
                player_2.Top += playerSpeed;
            }
            if (goUpPlayer2 && player_2.Top > 0)
            {
                player_2.Top -= playerSpeed;
            }


            // Проверка столкновений мяча с ракетками
            CheckCollision(ball, player_1, player_1.Right + 5);
            CheckCollision(ball, player_2, player_2.Left - 35);

            // Проверка условий победы
            if (playerScore_2 > 10)
            {
                GameOver($"{player_score_2.Text} - Ты проиграл!");              // Победа второго игрока 
            }
            else if (playerScore_1 > 10)
            {
                GameOver($"{player_score_1.Text} + Ты выиграл!");               // Победа первого игрока
            }
        }

        // Обработчик конца игры
        private void GameOver(string message)
        {
            gameTimer.Stop();                                 // Остановка игрового таймера

            // Вывод сообщения о результате
            MessageBox.Show(message, "Результат: ");

            // Сброс игровых параметров
            playerScore_2 = 0;
            playerScore_1 = 0;
            ballX = ballY = 4;
            speed = 50;

            gameTimer.Start();                                // Возобновление игры
        }

        // Проверка столкновений мяча с ракетками
        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {
            // Проверка пересечения объектов
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                PicOne.Left = offset;                         // Корректировка позиции мяча

                // Случайное изменение направления отскока
                int x = j[rand.Next(j.Length)];
                int y = j[rand.Next(j.Length)];

                if (ballX < 0) { ballX = x; }
                else { ballX = -x; }

                if (ballY < 0) { ballY = -y; }
                else { ballY = y; }
            }
        }


        public async void connect(string name)
        {
            try
            {
                //Подключение к серверу
                socket.ConnectAsync("127.0.0.1", 8888);

                //playerScore_2.Text = name + ":";
                _name = name;
 
                //Создаем объект класса P_Server 
                P_Server play = new P_Server("name", name);


                //Сериализуем объект P_Server в json строку   ->    {"Command":"name","Text":"$textBox1.Text$"}
                string json_msg = JsonSerializer.Serialize(play);

                //формируем байтовый массив из строки json_msg
                byte[] requestData = Encoding.UTF8.GetBytes(json_msg + '\n');
                //отправляем сообщение серверу
                await socket.SendAsync(requestData, SocketFlags.None);
            }
            catch (SocketException)
            {
                Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint}");
            }
        }
    }
}
