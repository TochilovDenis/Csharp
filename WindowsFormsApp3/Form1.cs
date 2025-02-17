using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            //saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем путь к выбранному файлу
            string filename = openFileDialog1.FileName;
            if (filename.IndexOf("txt") >0) { 
                // читаем файл в строку
                string fileText = System.IO.File.ReadAllText(filename);
                richTextBox1.Text = fileText;
                MessageBox.Show("Файл открыт");
            }

            if (filename.IndexOf("png") > 0)
            {
                // читаем файл в строку
                string file = System.IO.File.ReadAllText(filename);
                
                pictureBox1.Image = Image.FromFile(filename);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                MessageBox.Show("Файл открыт");
            }

            //richTextBox1.Text = Clipboard.GetText();
            //pictureBox1.Load(Clipboard.GetText());

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            if (filename.IndexOf("txt") > 0)
            {
                // сохраняем текст в файл
                System.IO.File.WriteAllText(filename, richTextBox1.Text);
                MessageBox.Show("Файл сохранен");
            }

        }
    }
}
