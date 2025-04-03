using server_cns1;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace client_wf1
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
            //Подключение к серверу
            socket.ConnectAsync("127.0.0.1", 8888);

            string msg = textBox1.Text;

            //Создаем объект класса Msg_t_c 
            Msg_t_c Msg_t_c = new Msg_t_c("name", msg, null);

            //Сериализуем объект Msg_t_c в json строку   ->    {"Command":"name","Text":"$textBox1.Text$"}
            string json_msg = JsonSerializer.Serialize(Msg_t_c);

            //формируем байтовый массив из строки json_msg
            byte[] requestData = Encoding.UTF8.GetBytes(json_msg + '\n');

            //отправляем сообщение серверу
            await socket.SendAsync(requestData, SocketFlags.None);

            groupBox1.Visible = false;
            groupBox1.Enabled = false;

            // запуск задачи на прослушивание сервера
            receive_(socket);

        }


        async Task receive_(Socket socket)
        {
            try
            {
                while (true)
                {
                    // буфер для накопления входящих данных
                    var buffer = new List<byte>();

                    // буфер для считывания одного байта
                    var bytesRead = new byte[1];

                    // считываем данные до конечного символа
                    while (true)
                    {
                        var count = await socket.ReceiveAsync(bytesRead, SocketFlags.None);
                        // смотрим, если считанный байт представляет конечный символ, выходим
                        if (count == 0 || bytesRead[0] == '\n') break;
                        // иначе добавляем в буфер
                        buffer.Add(bytesRead[0]);
                    }

                    string responseText = Encoding.UTF8.GetString(buffer.ToArray());

                    /*
                    // получаем данные из потока
                    int bytes = await socket.ReceiveAsync(buffer, SocketFlags.None);

                    //считыванием массив байт в строку  
                    string responseText = Encoding.UTF8.GetString(buffer, 0, bytes);*/

                    //Десериализации json строку в объект Msg_t_c /  {"Command":"name","Text":"$textBox1.Text$"} to  Msg_t_c("Command", "Text")

                    richTextBox1.Text += responseText + "\n";

                    Msg_t? r_m_t = JsonSerializer.Deserialize<Msg_t>(responseText);

                    add_mgs(r_m_t);
                    /*richTextBox1.Text += r_m_t.Text;*/

                }
            }
            catch (SocketException)
            {
                Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint}");
            }
        }


        public void add_mgs(Msg_t r_m_t) {
            TextBox textbox1 = new TextBox();

            textbox1.BackColor = System.Drawing.SystemColors.Menu;
            textbox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textbox1.ForeColor = System.Drawing.Color.Green;
            textbox1.Size = new System.Drawing.Size(flowLayoutPanel1.Size.Width-20, 16);

            textbox1.Text = r_m_t.Sender +" : "+ r_m_t.Text;

            if (r_m_t.Command.IndexOf("my_msg") == 0) {
                textbox1.Text = r_m_t.Text;
                textbox1.ForeColor = System.Drawing.Color.Blue;
                textbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            }
           
            if (r_m_t.Command.IndexOf("list_client") == 0)
            {
                textbox1.Text = JsonSerializer.Serialize(r_m_t.People);
            }

            flowLayoutPanel1.Controls.Add(textbox1);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                string msg = richTextBox2.Text;

                //Создаем объект класса Msg_t_c 
                Msg_t_c Msg_t_c = new Msg_t_c("msg", msg, null);

                //Сериализуем объект Msg_t_c в json строку   ->    {"Command":"name","Text":"$textBox1.Text$"}
                string json_msg = JsonSerializer.Serialize(Msg_t_c);

                //формируем байтовый массив из строки json_msg
                byte[] requestData = Encoding.UTF8.GetBytes(json_msg + '\n');

                // отправляем данные
                await socket.SendAsync(requestData, SocketFlags.None);

                richTextBox2.Text = "";

            }
            catch (SocketException)
            {
                Console.WriteLine($"Не удалось установить подключение с {socket.RemoteEndPoint}");
            }

        }
        public void msg_add(Msg_t_c r_m_t) {

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

        private async void button3_Click(object sender, EventArgs e)
        {

            //Создаем объект класса Msg_t_c 
            Msg_t_c Msg_t_c = new Msg_t_c("get_clients", "", null);

            //Сериализуем объект Msg_t_c в json строку   ->    {"Command":"name","Text":"$textBox1.Text$"}
            string json_msg = JsonSerializer.Serialize(Msg_t_c);

            //формируем байтовый массив из строки json_msg
            byte[] requestData = Encoding.UTF8.GetBytes(json_msg+ '\n');

            // отправляем данные
            await socket.SendAsync(requestData, SocketFlags.None);


        }
    }
}