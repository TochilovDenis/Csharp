using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoreGames;

namespace Ping_Pong
{
    public partial class User : Form
    {
        private Client_test client_Test;

        public User()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            PlayerPlayer form2 = new PlayerPlayer();
            form2.Show();
            client_Test = new Client_test();

            //form2.connect(textBox1.Text);
            this.Hide();
        }

        private void btn_create_room_Click(object sender, EventArgs e)
        {
            client_Test.Send("cr_r; name_room");
        }

        private void btn_connect_room_Click(object sender, EventArgs e)
        {
            client_Test.Send("cnt;name_room");
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            client_Test.Send("cr_r;name_room");
        }
    }
}
