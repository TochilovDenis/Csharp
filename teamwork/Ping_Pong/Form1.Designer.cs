namespace Ping_Pong
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
            components = new System.ComponentModel.Container();
            player = new PictureBox();
            cpu = new PictureBox();
            ball = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            playerScore = new Label();
            cpuScore = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cpu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // player
            // 
            player.BackColor = Color.CadetBlue;
            player.Image = Properties.Resources.player;
            player.Location = new Point(12, 186);
            player.Name = "player";
            player.Size = new Size(27, 127);
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.TabIndex = 0;
            player.TabStop = false;
            // 
            // cpu
            // 
            cpu.BackColor = Color.CadetBlue;
            cpu.Image = Properties.Resources.computer;
            cpu.Location = new Point(887, 186);
            cpu.Name = "cpu";
            cpu.Size = new Size(27, 127);
            cpu.SizeMode = PictureBoxSizeMode.StretchImage;
            cpu.TabIndex = 1;
            cpu.TabStop = false;
            // 
            // ball
            // 
            ball.BackColor = Color.CadetBlue;
            ball.BackgroundImage = Properties.Resources.ball;
            ball.Image = Properties.Resources.ball;
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
            // playerScore
            // 
            playerScore.AutoSize = true;
            playerScore.BackColor = Color.CadetBlue;
            playerScore.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            playerScore.ForeColor = Color.DarkOrange;
            playerScore.Location = new Point(212, 9);
            playerScore.Name = "playerScore";
            playerScore.Size = new Size(48, 32);
            playerScore.TabIndex = 4;
            playerScore.Text = "00";
            // 
            // cpuScore
            // 
            cpuScore.AutoSize = true;
            cpuScore.BackColor = Color.CadetBlue;
            cpuScore.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cpuScore.ForeColor = Color.DarkOliveGreen;
            cpuScore.Location = new Point(724, 9);
            cpuScore.Name = "cpuScore";
            cpuScore.Size = new Size(48, 32);
            cpuScore.TabIndex = 5;
            cpuScore.Text = "00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.CadetBlue;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(108, 9);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 6;
            label1.Text = "Player:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.CadetBlue;
            label2.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            label2.ForeColor = Color.DarkOliveGreen;
            label2.Location = new Point(644, 9);
            label2.Name = "label2";
            label2.Size = new Size(85, 32);
            label2.TabIndex = 7;
            label2.Text = "CPU:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(926, 566);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cpuScore);
            Controls.Add(playerScore);
            Controls.Add(ball);
            Controls.Add(cpu);
            Controls.Add(player);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Pong Game";
            KeyDown += keyIsDown;
            KeyUp += keyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)cpu).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox player;
        private PictureBox cpu;
        private PictureBox ball;
        private System.Windows.Forms.Timer gameTimer;
        private Label playerScore;
        private Label cpuScore;
        private Label label1;
        private Label label2;
    }
}
