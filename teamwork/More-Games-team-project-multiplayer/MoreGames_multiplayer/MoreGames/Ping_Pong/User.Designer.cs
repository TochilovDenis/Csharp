namespace Ping_Pong
{
    partial class User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            btn_connect = new Button();
            label1 = new Label();
            btn_create_room = new Button();
            btn_connect_room = new Button();
            btn_up = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(362, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 27);
            textBox1.TabIndex = 0;
            // 
            // btn_connect
            // 
            btn_connect.Location = new Point(561, 41);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(94, 29);
            btn_connect.TabIndex = 2;
            btn_connect.Text = "connect";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 50);
            label1.Name = "label1";
            label1.Size = new Size(282, 20);
            label1.TabIndex = 1;
            label1.Text = "Введите ваше имя для первого игрока:";
            // 
            // btn_create_room
            // 
            btn_create_room.Location = new Point(104, 96);
            btn_create_room.Name = "btn_create_room";
            btn_create_room.Size = new Size(171, 29);
            btn_create_room.TabIndex = 3;
            btn_create_room.Text = "Создать комнату";
            btn_create_room.UseVisualStyleBackColor = true;
            btn_create_room.Click += btn_create_room_Click;
            // 
            // btn_connect_room
            // 
            btn_connect_room.Location = new Point(308, 96);
            btn_connect_room.Name = "btn_connect_room";
            btn_connect_room.Size = new Size(171, 29);
            btn_connect_room.TabIndex = 4;
            btn_connect_room.Text = "Присоединиться";
            btn_connect_room.UseVisualStyleBackColor = true;
            btn_connect_room.Click += btn_connect_room_Click;
            // 
            // btn_up
            // 
            btn_up.Location = new Point(521, 97);
            btn_up.Name = "btn_up";
            btn_up.Size = new Size(94, 29);
            btn_up.TabIndex = 5;
            btn_up.Text = "up";
            btn_up.UseVisualStyleBackColor = true;
            btn_up.Click += btn_up_Click;
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 449);
            Controls.Add(btn_up);
            Controls.Add(btn_connect_room);
            Controls.Add(btn_create_room);
            Controls.Add(btn_connect);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "User";
            Text = "User";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btn_connect;
        private Label label1;
        private Button btn_create_room;
        private Button btn_connect_room;
        private Button btn_up;
    }
}