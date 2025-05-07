using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            PlayerPlayer form2 = new PlayerPlayer();
            form2.Show();
            form2.connect(textBox1.Text);
            this.Hide();
        }
    }
}
