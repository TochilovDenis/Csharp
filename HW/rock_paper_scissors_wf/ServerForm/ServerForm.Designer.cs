namespace rock_paper_scissors_s
{
    partial class ServerForm
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
            statusLog = new RichTextBox();
            startBtn = new Button();
            SuspendLayout();
            // 
            // statusLog
            // 
            statusLog.Location = new Point(12, 12);
            statusLog.Name = "statusLog";
            statusLog.Size = new Size(438, 357);
            statusLog.TabIndex = 0;
            statusLog.Text = "";
            // 
            // startBtn
            // 
            startBtn.Location = new Point(119, 392);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(225, 46);
            startBtn.TabIndex = 1;
            startBtn.Text = "Подключить к серверу";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += StartServer;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 450);
            Controls.Add(startBtn);
            Controls.Add(statusLog);
            Name = "ServerForm";
            Text = "Сервер игры";
            ResumeLayout(false);
        }
        #endregion
     
        private RichTextBox statusLog;
        private Button startBtn;
    }
}
