namespace Pipes
{
    partial class frmMain
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
            this.btnSend = new System.Windows.Forms.Button();
            this.lblPipe = new System.Windows.Forms.Label();
            this.tbPipe = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(285, 77);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(103, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblPipe
            // 
            this.lblPipe.AutoSize = true;
            this.lblPipe.Location = new System.Drawing.Point(12, 9);
            this.lblPipe.Name = "lblPipe";
            this.lblPipe.Size = new System.Drawing.Size(72, 26);
            this.lblPipe.TabIndex = 1;
            this.lblPipe.Text = "Введите имя\r\nканала";
            // 
            // tbPipe
            // 
            this.tbPipe.Location = new System.Drawing.Point(90, 15);
            this.tbPipe.Name = "tbPipe";
            this.tbPipe.Size = new System.Drawing.Size(188, 20);
            this.tbPipe.TabIndex = 0;
            this.tbPipe.Text = "\\\\.\\pipe\\ServerPipe";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(13, 82);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Сообщение";
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(91, 79);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(188, 20);
            this.tbMessage.TabIndex = 1;
            // 
            // rtbMessages
            // 
            this.rtbMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbMessages.Location = new System.Drawing.Point(0, 106);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.Size = new System.Drawing.Size(393, 268);
            this.rtbMessages.TabIndex = 3;
            this.rtbMessages.Text = "";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(91, 53);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(188, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 56);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Имя";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(284, 15);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(103, 22);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "Подключиться";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 374);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.tbPipe);
            this.Controls.Add(this.lblPipe);
            this.Controls.Add(this.btnSend);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblPipe;
        private System.Windows.Forms.TextBox tbPipe;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonConnect;
    }
}