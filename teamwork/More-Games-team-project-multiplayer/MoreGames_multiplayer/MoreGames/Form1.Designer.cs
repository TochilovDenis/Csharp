namespace MoreGames
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
            RememberGame = new Button();
            FlappyBird = new Button();
            TicTacToe = new Button();
            Memo = new Button();
            Ping_Pong = new Button();
            Create_room = new Button();
            Connect_room = new Button();
            CreateServer = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // RememberGame
            // 
            RememberGame.Location = new Point(275, 155);
            RememberGame.Margin = new Padding(3, 4, 3, 4);
            RememberGame.Name = "RememberGame";
            RememberGame.Size = new Size(104, 107);
            RememberGame.TabIndex = 0;
            RememberGame.Text = "Игра на запоминание";
            RememberGame.UseVisualStyleBackColor = true;
            RememberGame.Click += RememberGame_Click;
            // 
            // FlappyBird
            // 
            FlappyBird.Location = new Point(405, 155);
            FlappyBird.Margin = new Padding(3, 4, 3, 4);
            FlappyBird.Name = "FlappyBird";
            FlappyBird.Size = new Size(104, 107);
            FlappyBird.TabIndex = 1;
            FlappyBird.Text = "flappy bird";
            FlappyBird.UseVisualStyleBackColor = true;
            FlappyBird.Click += FlappyBird_Click;
            // 
            // TicTacToe
            // 
            TicTacToe.Location = new Point(530, 155);
            TicTacToe.Margin = new Padding(3, 4, 3, 4);
            TicTacToe.Name = "TicTacToe";
            TicTacToe.Size = new Size(104, 107);
            TicTacToe.TabIndex = 1;
            TicTacToe.Text = "Крестики нолики";
            TicTacToe.UseVisualStyleBackColor = true;
            TicTacToe.Click += TicTacToe_Click;
            // 
            // Memo
            // 
            Memo.Location = new Point(658, 155);
            Memo.Margin = new Padding(3, 4, 3, 4);
            Memo.Name = "Memo";
            Memo.Size = new Size(104, 107);
            Memo.TabIndex = 2;
            Memo.Text = "Подберите пару (не точно)";
            Memo.UseVisualStyleBackColor = true;
            Memo.Click += Memo_Click;
            // 
            // Ping_Pong
            // 
            Ping_Pong.Location = new Point(781, 155);
            Ping_Pong.Margin = new Padding(3, 4, 3, 4);
            Ping_Pong.Name = "Ping_Pong";
            Ping_Pong.Size = new Size(104, 107);
            Ping_Pong.TabIndex = 2;
            Ping_Pong.Text = "Пинг Понг";
            Ping_Pong.UseVisualStyleBackColor = true;
            Ping_Pong.Click += Tetris_Click;
            // 
            // Create_room
            // 
            Create_room.Location = new Point(275, 523);
            Create_room.Margin = new Padding(3, 4, 3, 4);
            Create_room.Name = "Create_room";
            Create_room.Size = new Size(199, 77);
            Create_room.TabIndex = 3;
            Create_room.Text = "Создать комнату";
            Create_room.UseVisualStyleBackColor = true;
            Create_room.Click += Create_room_Click;
            // 
            // Connect_room
            // 
            Connect_room.Location = new Point(686, 523);
            Connect_room.Margin = new Padding(3, 4, 3, 4);
            Connect_room.Name = "Connect_room";
            Connect_room.Size = new Size(199, 77);
            Connect_room.TabIndex = 4;
            Connect_room.Text = "присоединится";
            Connect_room.UseVisualStyleBackColor = true;
            Connect_room.Click += Connect_room_Click;
            // 
            // CreateServer
            // 
            CreateServer.Location = new Point(275, 608);
            CreateServer.Margin = new Padding(3, 4, 3, 4);
            CreateServer.Name = "CreateServer";
            CreateServer.Size = new Size(199, 83);
            CreateServer.TabIndex = 5;
            CreateServer.Text = "Создать сервер";
            CreateServer.UseVisualStyleBackColor = true;
            CreateServer.Click += CreateServer_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 796);
            Controls.Add(CreateServer);
            Controls.Add(Connect_room);
            Controls.Add(Create_room);
            Controls.Add(Ping_Pong);
            Controls.Add(Memo);
            Controls.Add(TicTacToe);
            Controls.Add(FlappyBird);
            Controls.Add(RememberGame);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button RememberGame;
        private Button FlappyBird;
        private Button TicTacToe;
        private Button Memo;
        private Button Ping_Pong;
        private Button Create_room;
        private Button Connect_room;
        private Button CreateServer;
        private OpenFileDialog openFileDialog1;
    }
}
