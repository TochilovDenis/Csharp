namespace Ping_Pong
{
    partial class Ping_Pong_Games
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
            player_and_cpu = new Button();
            game_with_user = new Button();
            quit = new Button();
            SuspendLayout();
            // 
            // player_and_cpu
            // 
            player_and_cpu.Location = new Point(40, 49);
            player_and_cpu.Name = "player_and_cpu";
            player_and_cpu.Size = new Size(221, 29);
            player_and_cpu.TabIndex = 0;
            player_and_cpu.Text = "Играть с компьютером";
            player_and_cpu.UseVisualStyleBackColor = true;
            player_and_cpu.Click += player_and_cpu_Click;
            // 
            // game_with_user
            // 
            game_with_user.Location = new Point(40, 103);
            game_with_user.Name = "game_with_user";
            game_with_user.Size = new Size(221, 29);
            game_with_user.TabIndex = 1;
            game_with_user.Text = "Игра с пользователем";
            game_with_user.UseVisualStyleBackColor = true;
            game_with_user.Click += game_with_user_Click;
            // 
            // quit
            // 
            quit.Location = new Point(106, 163);
            quit.Name = "quit";
            quit.Size = new Size(94, 29);
            quit.TabIndex = 2;
            quit.Text = "Выход";
            quit.UseVisualStyleBackColor = true;
            quit.Click += quit_Click;
            // 
            // Ping_Pong_Games
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 234);
            Controls.Add(quit);
            Controls.Add(game_with_user);
            Controls.Add(player_and_cpu);
            Name = "Ping_Pong_Games";
            Text = "PingPongGames";
            ResumeLayout(false);
        }

        #endregion

        private Button player_and_cpu;
        private Button game_with_user;
        private Button quit;
    }
}