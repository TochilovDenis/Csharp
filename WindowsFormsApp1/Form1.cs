using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int sum = 0;
        public String fnc = "+"; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calc(1);
        }

        public void calc(int n) {
            if (fnc == "+")
                sum = sum + n;
               
            textBox1.Text = "sum = " + sum;
        }
    }
}
