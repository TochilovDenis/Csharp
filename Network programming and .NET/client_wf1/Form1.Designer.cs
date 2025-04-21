namespace client_wf1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox2 = new RichTextBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            button2 = new Button();
            textBox1 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button3 = new Button();
            richTextBox1 = new RichTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(14, 583);
            richTextBox2.Margin = new Padding(3, 4, 3, 4);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(445, 64);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = "";
            richTextBox2.UseWaitCursor = true;
            // 
            // button1
            // 
            button1.Location = new Point(466, 583);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(95, 65);
            button1.TabIndex = 2;
            button1.Text = "отправить";
            button1.UseVisualStyleBackColor = true;
            button1.UseWaitCursor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(596, 39);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(460, 524);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Регистрация";
            groupBox1.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 146);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 2;
            label1.Text = "Введите ваше имя";
            label1.UseWaitCursor = true;
            // 
            // button2
            // 
            button2.Location = new Point(176, 254);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 1;
            button2.Text = "connect";
            button2.UseVisualStyleBackColor = true;
            button2.UseWaitCursor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(111, 193);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(228, 27);
            textBox1.TabIndex = 0;
            textBox1.UseWaitCursor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(14, 39);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(547, 524);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.UseWaitCursor = true;
            // 
            // button3
            // 
            button3.Location = new Point(14, 657);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(159, 31);
            button3.TabIndex = 5;
            button3.Text = "Список клиента";
            button3.UseVisualStyleBackColor = true;
            button3.UseWaitCursor = true;
            button3.Click += button3_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(596, 39);
            richTextBox1.Margin = new Padding(3, 4, 3, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(460, 524);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            richTextBox1.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 718);
            Controls.Add(button3);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(richTextBox2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(richTextBox1);
            Cursor = Cursors.WaitCursor;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Чатик";
            UseWaitCursor = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private RichTextBox richTextBox2;
        private Button button1;
        private GroupBox groupBox1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button3;
        private RichTextBox richTextBox1;
    }
}