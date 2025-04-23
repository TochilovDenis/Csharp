namespace Ping_Pong
{
    public partial class Form1 : Form
    {
        // Игровые параметры
        private Random rand = new Random();                   // Генератор случайных чисел
        private bool goUp;                                    // Флаг движения игрока вверх
        private bool goDown;                                  // Флаг движения игрока вниз

        // Скоростные характеристики        
        private const int DEFAULT_SPEED = 5;                  // Базовая скорость мяча
        private int speed = DEFAULT_SPEED;                    // Текущая скорость мяча
        private int ballX = 5;                                // Горизонтальная компонента скорости мяча
        private int ballY = 5;                                // Вертикальная компонента скорости мяча

        // Система подсчета очков
        int player_score = 0;    // Очки игрока
        int cpu_score = 0;       // Очки компьютера

        // Параметры ИИ компьютера
        int computer_speed_change = 50;                      // Счетчик смены скорости компьютера
        int playerSpeed = 8;                                 // Скорость движения игрока

        // Массивы для случайной генерации скоростей
        int[] i = { 5, 6, 8, 9 };                            // Варианты горизонтальной скорости мяча
        int[] j = { 10, 9, 8, 11, 12 };                      // Варианты вертикальной скорости мяча

        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик нажатия клавиш управления
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;                                  // Активация движения вверх
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;                                // Активация движения вниз
            }
        }

        // Обработчик отпускания клавиш управления
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;                                 // Деактивация движения вверх
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;                               // Деактивация движения вниз
            }
        }

        // Основной игровой тикер
        private void timerTick(object sender, EventArgs e)
        {
            // Обновление позиции мяча
            ball.Top -= ballY;
            ball.Left -= ballX;

            // Обновление отображения счета
            playerScore.Text = "" + player_score;             // Отображение очков игрока
            cpuScore.Text = "" + cpu_score;                   // Отображение очков компьютера

            // Обработка столкновений со стенами
            if (ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
            {
                ballY = -ballY;                               // Отражение от верхней и нижней стены
            }

            // Проверка гола игроку
            if (ball.Left < -2)
            {
                ball.Left = 300;
                ballX = -ballX;
                cpu_score++;                                  // Очки компьютеру
            }

            // Проверка гола компьютеру
            if (ball.Right > this.ClientSize.Width + 2)
            {
                ball.Left = 300;
                ballX = -ballX;
                player_score++;                               // Очки игроку
            }

            // Ограничение движения ракетки компьютера
            if (cpu.Top <= 1)
            {
                cpu.Top = 0;                                  // Верхний предел
            }
            else if (cpu.Bottom >= this.ClientSize.Height)
            {
                cpu.Top = this.ClientSize.Height - cpu.Height; // Нижний предел
            }

            // Логика компьютера
            if (ball.Top < cpu.Top + (cpu.Height / 2) && ball.Left > 300)
            {
                cpu.Top -= speed;                            // Движение вверх
            }
            if (ball.Top > cpu.Top + (cpu.Height / 2) && ball.Left > 300)
            {
                cpu.Top += speed;                            // Движение вниз
            }

            // Система изменения скорости компьютера
            computer_speed_change -= 1;
            if (computer_speed_change < 0)
            {
                speed = i[rand.Next(i.Length)];              // Случайная смена скорости
                computer_speed_change = 50;
            }

            // Управление ракеткой игрока
            if (goDown && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += playerSpeed;                    // Движение вниз
            }
            if (goUp && player.Top > 0)
            {
                player.Top -= playerSpeed;                    // Движение вверх
            }

            // Проверка столкновений мяча с ракетками
            CheckCollision(ball, player, player.Right + 5);
            CheckCollision(ball, cpu, cpu.Left - 35);

            // Проверка условий победы
            if (cpu_score > 10)
            {
                GameOver("Ты проиграл!");                     // Победа компьютера
            }
            else if (player_score > 10)
            {
                GameOver("Ты выиграл!");                      // Победа игрока
            }
        }

        // Обработчик конца игры
        private void GameOver(string message)
        {
            gameTimer.Stop();                                 // Остановка игрового таймера

            // Вывод сообщения о результате
            MessageBox.Show(message, "Результат: ");

            // Сброс игровых параметров
            cpu_score = 0;
            player_score = 0;
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
    }
}
