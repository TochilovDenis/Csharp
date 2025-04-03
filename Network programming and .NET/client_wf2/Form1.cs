using server_cns1;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace client_wf2
{
    public partial class Form1 : Form
    {
        public Socket socket;
        public Form1()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //����������� � �������
            socket.ConnectAsync("127.0.0.1", 8888);

            string msg = textBox1.Text;

            //������� ������ ������ Msg_t 
            Msg_t msg_t = new Msg_t("name", msg);

            //����������� ������ msg_t � json ������   ->    {"Command":"name","Text":"$textBox1.Text$"}
            string json_msg = JsonSerializer.Serialize(msg_t);

            //��������� �������� ������ �� ������ json_msg
            byte[] requestData = Encoding.UTF8.GetBytes(json_msg);

            //���������� ��������� �������
            await socket.SendAsync(requestData, SocketFlags.None);

            groupBox1.Visible = false;
            groupBox1.Enabled = false;

            // ������ ������ �� ������������� �������
            receive_(socket);

        }


        async Task receive_(Socket socket)
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[512];

                    // �������� ������ �� ������
                    int bytes = await socket.ReceiveAsync(buffer, SocketFlags.None);

                    //����������� ������ ���� � ������  
                    string responseText = Encoding.UTF8.GetString(buffer, 0, bytes);

                    //�������������� json ������ � ������ msg_t /  {"Command":"name","Text":"$textBox1.Text$"} to  Msg_t("Command", "Text")
                    Msg_t? r_m_t = JsonSerializer.Deserialize<Msg_t>(responseText);

                    add_mgs(r_m_t);
                    /*richTextBox1.Text += r_m_t.Text;*/

                }
            }
            catch (SocketException)
            {
                Console.WriteLine($"�� ������� ���������� ����������� � {socket.RemoteEndPoint}");
            }
        }


        public void add_mgs(Msg_t r_m_t) {


            TextBox textbox1 = new TextBox();


            textbox1.BackColor = System.Drawing.SystemColors.Menu;
            textbox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textbox1.ForeColor = System.Drawing.Color.Green;
            textbox1.Size = new System.Drawing.Size(flowLayoutPanel1.Size.Width-20, 16);


            textbox1.Text = r_m_t.Text;

            if (r_m_t.Command.IndexOf("my_msg") == 0) {
                textbox1.ForeColor = System.Drawing.Color.Blue;
                textbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            }

            flowLayoutPanel1.Controls.Add(textbox1);
        }







        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                string msg = richTextBox2.Text;

                //������� ������ ������ Msg_t 
                Msg_t msg_t = new Msg_t("msg", msg);

                //����������� ������ msg_t � json ������   ->    {"Command":"name","Text":"$textBox1.Text$"}
                string json_msg = JsonSerializer.Serialize(msg_t);

                //��������� �������� ������ �� ������ json_msg
                byte[] requestData = Encoding.UTF8.GetBytes(json_msg);

                // ���������� ������
                await socket.SendAsync(requestData, SocketFlags.None);

                richTextBox2.Text = "";

            }
            catch (SocketException)
            {
                Console.WriteLine($"�� ������� ���������� ����������� � {socket.RemoteEndPoint}");
            }

        }
        public void msg_add(Msg_t r_m_t) {

            TextBox textBox1 = new TextBox();
            textBox1.Text = r_m_t.Text;

            textBox1.BackColor = System.Drawing.SystemColors.Control;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Margin = new System.Windows.Forms.Padding(3);
            textBox1.Padding = new System.Windows.Forms.Padding(3);
            textBox1.ForeColor = System.Drawing.Color.Green;
            textBox1.Size = new System.Drawing.Size(flowLayoutPanel1.Size.Width-10, 23);

            if (r_m_t.Command.IndexOf("my_msg") == 0) {
                textBox1.ForeColor = System.Drawing.Color.Blue;
                textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            }


            flowLayoutPanel1.Controls.Add(textBox1);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}