namespace Ping_Pong
{
    public partial class Ping_Pong_Games : Form
    {
        const int code = -1;
    
        public Ping_Pong_Games()
        {
            InitializeComponent();
        }

        private void player_and_cpu_Click(object sender, EventArgs e)
        {
            PlayerCPU form1 = new PlayerCPU();
            form1.Show();
            this.Hide();
        }

        private void game_with_user_Click(object sender, EventArgs e)
        {
            User form4 = new User();
            form4.Show();
            this.Hide();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Environment.Exit(code);
        }
    }
}
