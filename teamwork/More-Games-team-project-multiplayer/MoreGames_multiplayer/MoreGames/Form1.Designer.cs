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
            Tetris = new Button();
            Create_room = new Button();
            Connect_room = new Button();
            CreateServer = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // RememberGame
            // 
            RememberGame.Location = new Point(241, 116);
            RememberGame.Name = "RememberGame";
            RememberGame.Size = new Size(91, 80);
            RememberGame.TabIndex = 0;
            RememberGame.Text = "Игра на запоминание";
            RememberGame.UseVisualStyleBackColor = true;
            RememberGame.Click += RememberGame_Click;
            // 
            // FlappyBird
            // 
            FlappyBird.Location = new Point(354, 116);
            FlappyBird.Name = "FlappyBird";
            FlappyBird.Size = new Size(91, 80);
            FlappyBird.TabIndex = 1;
            FlappyBird.Text = "flappy bird";
            FlappyBird.UseVisualStyleBackColor = true;
            FlappyBird.Click += FlappyBird_Click;
            // 
            // TicTacToe
            // 
            TicTacToe.Location = new Point(464, 116);
            TicTacToe.Name = "TicTacToe";
            TicTacToe.Size = new Size(91, 80);
            TicTacToe.TabIndex = 1;
            TicTacToe.Text = "Крестики нолики";
            TicTacToe.UseVisualStyleBackColor = true;
            TicTacToe.Click += TicTacToe_Click;
            // 
            // Memo
            // 
            Memo.Location = new Point(576, 116);
            Memo.Name = "Memo";
            Memo.Size = new Size(91, 80);
            Memo.TabIndex = 2;
            Memo.Text = "Подберите пару (не точно)";
            Memo.UseVisualStyleBackColor = true;
            Memo.Click += Memo_Click;
            // 
            // Tetris
            // 
            Tetris.Location = new Point(683, 116);
            Tetris.Name = "Tetris";
            Tetris.Size = new Size(91, 80);
            Tetris.TabIndex = 2;
            Tetris.Text = "тетрис";
            Tetris.UseVisualStyleBackColor = true;
            Tetris.Click += Tetris_Click;
            // 
            // Create_room
            // 
            Create_room.Location = new Point(241, 392);
            Create_room.Name = "Create_room";
            Create_room.Size = new Size(174, 58);
            Create_room.TabIndex = 3;
            Create_room.Text = "Создать комнату";
            Create_room.UseVisualStyleBackColor = true;
            Create_room.Click += Create_room_Click;
            // 
            // Connect_room
            // 
            Connect_room.Location = new Point(600, 392);
            Connect_room.Name = "Connect_room";
            Connect_room.Size = new Size(174, 58);
            Connect_room.TabIndex = 4;
            Connect_room.Text = "присоединится";
            Connect_room.UseVisualStyleBackColor = true;
            Connect_room.Click += Connect_room_Click;
            // 
            // CreateServer
            // 
            CreateServer.Location = new Point(241, 456);
            CreateServer.Name = "CreateServer";
            CreateServer.Size = new Size(174, 62);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 597);
            Controls.Add(CreateServer);
            Controls.Add(Connect_room);
            Controls.Add(Create_room);
            Controls.Add(Tetris);
            Controls.Add(Memo);
            Controls.Add(TicTacToe);
            Controls.Add(FlappyBird);
            Controls.Add(RememberGame);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button RememberGame;
        private Button FlappyBird;
        private Button TicTacToe;
        private Button Memo;
        private Button Tetris;
        private Button Create_room;
        private Button Connect_room;
        private Button CreateServer;
        private OpenFileDialog openFileDialog1;
    }
}
