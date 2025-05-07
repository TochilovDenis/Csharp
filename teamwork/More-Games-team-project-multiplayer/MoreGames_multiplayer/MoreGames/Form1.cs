using System.Diagnostics;
using Ping_Pong;

namespace MoreGames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RememberGame_Click(object sender, EventArgs e)
        {

        }

        private void FlappyBird_Click(object sender, EventArgs e)
        {

        }

        private void TicTacToe_Click(object sender, EventArgs e)
        {

        }

        private void Memo_Click(object sender, EventArgs e)
        {

        }

        private void Tetris_Click(object sender, EventArgs e)
        {
            Ping_Pong_Games pp = new Ping_Pong_Games();
            pp.Show();
        }

        private void Connect_room_Click(object sender, EventArgs e)
        {

        }

        private void Create_room_Click(object sender, EventArgs e)
        {


        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {

        }

        private void CreateServer_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            Process.Start(filename);
        }
    }
}
