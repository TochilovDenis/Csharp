namespace rock_paper_scissors
{
    partial class ClientForm
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
            connectBtn = new Button();
            sendMoveBtn = new Button();
            moveCombo = new ComboBox();
            statusLog = new RichTextBox();
            SuspendLayout();
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(309, 12);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(233, 45);
            connectBtn.TabIndex = 0;
            connectBtn.Text = "Подключиться к серверу";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += ConnectToServer;
            // 
            // sendMoveBtn
            // 
            sendMoveBtn.Location = new Point(309, 397);
            sendMoveBtn.Name = "sendMoveBtn";
            sendMoveBtn.Size = new Size(233, 45);
            sendMoveBtn.TabIndex = 1;
            sendMoveBtn.Text = "Сделать ход";
            sendMoveBtn.UseVisualStyleBackColor = true;
            sendMoveBtn.Click += SendMove;
            // 
            // moveCombo
            // 
            moveCombo.FormattingEnabled = true;
            moveCombo.Items.AddRange(new object[] { "Камень", "Ножницы", "Бумага", "Ящерица", "Спок" });
            moveCombo.Location = new Point(12, 63);
            moveCombo.Name = "moveCombo";
            moveCombo.Size = new Size(788, 28);
            moveCombo.TabIndex = 2;
            // 
            // statusLog
            // 
            statusLog.Location = new Point(12, 103);
            statusLog.Name = "statusLog";
            statusLog.Size = new Size(788, 278);
            statusLog.TabIndex = 3;
            statusLog.Text = "";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 454);
            Controls.Add(statusLog);
            Controls.Add(moveCombo);
            Controls.Add(sendMoveBtn);
            Controls.Add(connectBtn);
            Name = "ClientForm";
            Text = "Клиент игры";
            ResumeLayout(false);
        }

        #endregion

        private Button connectBtn;
        private Button sendMoveBtn;
        private ComboBox moveCombo;
        private RichTextBox statusLog;
    }
}
