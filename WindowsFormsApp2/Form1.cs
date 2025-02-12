using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public int sum = 0;
        public String fnc = "";
        public int var = 0;
        public String var2 = "";
        public String history = "";

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = sum.ToString();
            textBox2.Text = fnc;
            textBox3.Text = var2.ToString();
        }
        public void calc()
        {
            var = Convert.ToInt32(var2);

            history = history + "\n" + sum.ToString() + " " + fnc + " " + var.ToString();

            if (fnc == "+") { sum = sum + var; }
            if (fnc == "-") { sum = sum - var; }
            if (fnc == "*") { sum = sum * var; }
            if (fnc == "/") { sum = sum / var; }

            history = history + " = " + sum.ToString();

            fnc = "";
            var = 0;
            var2 = "";

            richTextBox1.Text = history;

            textBox1.Text = sum.ToString();
            textBox2.Text = fnc;
            textBox3.Text = var.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var = (var * 10) +1;
            var2 = var2 + "1";
            textBox3.Text = var.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 2;
            var2 = var2 + "2";
            textBox3.Text = var.ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 3;
            var2 = var2 + "3";
            textBox3.Text = var.ToString();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 4;
            var2 = var2 + "4";
            textBox3.Text = var.ToString();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 5;
            var2 = var2 + "5";
            textBox3.Text = var.ToString();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 6;
            var2 = var2 + "6";
            textBox3.Text = var.ToString();

        }
        private void button7_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 7;
            var2 = var2 + "7";
            textBox3.Text = var.ToString();

        }
        private void button8_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 8;
            var2 = var2 + "8";
            textBox3.Text = var.ToString();

        }
        private void button9_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 9;
            var2 = var2 + "9";
            textBox3.Text = var.ToString();

        }
        private void button10_Click(object sender, EventArgs e)
        {
            var = (var * 10) + 0;
            var2 = var2 + "0";
            textBox3.Text = var.ToString();

        }
        private void button11_Click(object sender, EventArgs e)
        {
            fnc = "+";
            textBox2.Text = "+"; 
        }
        private void button12_Click(object sender, EventArgs e)
        {
            fnc = "-";
            textBox2.Text = "-";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            fnc = "*";
            textBox2.Text = "*";

        }
        private void button14_Click(object sender, EventArgs e)
        {
            fnc = "/";
            textBox2.Text = "/";

        }
        private void button15_Click(object sender, EventArgs e)
        {
            calc();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var = 0;
            fnc = "";
            sum = 0;
            textBox1.Text = sum.ToString();
            textBox2.Text = fnc;
            textBox3.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var = 0;
            textBox3.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
