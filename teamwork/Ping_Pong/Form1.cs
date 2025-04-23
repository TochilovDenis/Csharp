using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using static System.Formats.Asn1.AsnWriter;

namespace Ping_Pong
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        bool goUp;        // для определения позиции игрока наверху
        bool goDown;      // для определения положения игрока внизу
        int speed = 5;    // скорость, поддерживающей значение 5
        int ballX = 5;    // горизонтальное значение скорости X для объекта-шара 
        int ballY = 5;    // значение вертикальной скорости Y для объекта-шара
        int player_score = 0;    // оценка для игрока
        int cpu_score = 0; // оценка для компьютера
        int computer_speed_change = 50;
        int playerSpeed = 8;
        int[] i = { 5, 6, 8, 9 };
        int[] j = { 10, 9, 8, 11, 12 };
        public Form1()
        {
            InitializeComponent();
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            ball.Top -= ballY;
            ball.Left -= ballX;

            playerScore.Text = "" + player_score; // Обновление отображения счета игрока
            cpuScore.Text = "" + cpu_score;       // Обновление отображения счета компьютера

            if (ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
            {
                ballY = -ballY;
            }
            if (ball.Left < -2)
            {
                ball.Left = 300;
                ballX = -ballX;
                cpu_score++;
            }
            if (ball.Right > this.ClientSize.Width + 2)
            {
                ball.Left = 300;
                ballX = -ballX;
                player_score++;
            }
            if (cpu.Top <= 1)
            {
                cpu.Top = 0;
            }
            else if (cpu.Bottom >= this.ClientSize.Height) 
            { 
                cpu.Top = this.ClientSize.Height - cpu.Height;
            }
            if (ball.Top <cpu.Top + (cpu.Height / 2) && ball.Left > 300)
            {
                cpu.Top -= speed;
            }
            if (ball.Top > cpu.Top + (cpu.Height / 2) && ball.Left > 300)
            {
                cpu.Top += speed;
            }
            computer_speed_change -= 1;
            if (computer_speed_change < 0)
            {
                speed = i[rand.Next(i.Length)];
                computer_speed_change = 50;
            }
            if (goDown && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += playerSpeed;
            }
            if (goUp && player.Top > 0)
            {
                player.Top -= playerSpeed;
            }
            CheckCollision(ball, player, player.Right + 5);
            CheckCollision(ball, cpu, cpu.Left - 35);
            if (cpu_score > 10)
            {
                GameOver("Ты проиграл!");
            }
            else if (player_score > 10)
            {
                GameOver("Ты выиграл!");
            }
        }

        private void GameOver(string message)
        {
            gameTimer.Stop();
            MessageBox.Show(message, "Результат: ");
            cpu_score = 0;
            player_score = 0;
            ballX = ballY = 4;
            speed = 50;
            gameTimer.Start();
        }

        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                PicOne.Left = offset;
                int x = j[rand.Next(j.Length)];
                int y = j[rand.Next(j.Length)];
                if (ballX < 0)
                {
                    ballX = x;
                }
                else
                {
                    ballX = -x;
                }
                if (ballY < 0)
                {
                    ballY = -y;
                }
                else
                {
                    ballY = y;
                }
            }
        }
    }
}
