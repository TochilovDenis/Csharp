namespace Ping_Pong
{
    public partial class Form3 : Form
    {
        const int code = -1;
        public Form3()
        {
            InitializeComponent();
        }

        private void player_and_cpu_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void game_with_user_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Environment.Exit(code);
        }
    }
}
