namespace Ping_Pong
{
    partial class PlayerPlayer
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerPlayer));
            player_1 = new PictureBox();
            player_2 = new PictureBox();
            ball = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            player_score_2 = new Label();
            player_score_1 = new Label();
            ((System.ComponentModel.ISupportInitialize)player_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // player_1
            // 
            player_1.BackColor = Color.CadetBlue;
            player_1.Image = (Image)resources.GetObject("player_1.Image");
            player_1.Location = new Point(12, 186);
            player_1.Name = "player_1";
            player_1.Size = new Size(27, 127);
            player_1.SizeMode = PictureBoxSizeMode.StretchImage;
            player_1.TabIndex = 0;
            player_1.TabStop = false;
            // 
            // player_2
            // 
            player_2.BackColor = Color.CadetBlue;
            player_2.Image = (Image)resources.GetObject("player_2.Image");
            player_2.Location = new Point(887, 186);
            player_2.Name = "player_2";
            player_2.Size = new Size(27, 127);
            player_2.SizeMode = PictureBoxSizeMode.StretchImage;
            player_2.TabIndex = 1;
            player_2.TabStop = false;
            // 
            // ball
            // 
            ball.BackColor = Color.CadetBlue;
            ball.Image = (Image)resources.GetObject("ball.Image");
            ball.Location = new Point(434, 239);
            ball.Name = "ball";
            ball.Size = new Size(27, 27);
            ball.SizeMode = PictureBoxSizeMode.StretchImage;
            ball.TabIndex = 2;
            ball.TabStop = false;
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += timerTick;
            // 
            // player_score_2
            // 
            player_score_2.AutoSize = true;
            player_score_2.BackColor = Color.CadetBlue;
            player_score_2.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            player_score_2.ForeColor = Color.DarkOliveGreen;
            player_score_2.Location = new Point(650, 9);
            player_score_2.Name = "player_score_2";
            player_score_2.Size = new Size(169, 32);
            player_score_2.TabIndex = 5;
            player_score_2.Text = "Player2: 00";
            // 
            // player_score_1
            // 
            player_score_1.AutoSize = true;
            player_score_1.BackColor = Color.CadetBlue;
            player_score_1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            player_score_1.ForeColor = Color.DarkGoldenrod;
            player_score_1.Location = new Point(118, 9);
            player_score_1.Name = "player_score_1";
            player_score_1.Size = new Size(169, 32);
            player_score_1.TabIndex = 7;
            player_score_1.Text = "Player1: 00";
            // 
            // PlayerPlayer
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(926, 566);
            Controls.Add(player_score_1);
            Controls.Add(player_score_2);
            Controls.Add(ball);
            Controls.Add(player_2);
            Controls.Add(player_1);
            DoubleBuffered = true;
            Name = "PlayerPlayer";
            Text = "Ping Pong Game";
            KeyDown += keyIsDown;
            KeyUp += keyIsUp;
            ((System.ComponentModel.ISupportInitialize)player_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)player_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox player_1;
        private PictureBox player_2;
        private PictureBox ball;
        private System.Windows.Forms.Timer gameTimer;
        private Label player_score_2;
        private Label player_score_1;
    }
}