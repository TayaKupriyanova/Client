namespace Client
{
    partial class fGetSign
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bLogOut = new System.Windows.Forms.Button();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.LoadFile = new System.Windows.Forms.Button();
            this.bSigh = new System.Windows.Forms.Button();
            this.bCheckSign = new System.Windows.Forms.Button();
            this.ViewSign = new System.Windows.Forms.Button();
            this.Signtb = new System.Windows.Forms.TextBox();
            this.GetPublicKey = new System.Windows.Forms.Button();
            this.ClearB = new System.Windows.Forms.Button();
            this.cbFiles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bLogOut);
            this.panel1.Controls.Add(this.LoginBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(22, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 74);
            this.panel1.TabIndex = 0;
            // 
            // bLogOut
            // 
            this.bLogOut.Location = new System.Drawing.Point(218, 37);
            this.bLogOut.Name = "bLogOut";
            this.bLogOut.Size = new System.Drawing.Size(110, 28);
            this.bLogOut.TabIndex = 1;
            this.bLogOut.Text = "Выйти из профиля";
            this.bLogOut.UseVisualStyleBackColor = true;
            this.bLogOut.Click += new System.EventHandler(this.bLogOut_Click);
            // 
            // LoginBox
            // 
            this.LoginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginBox.Location = new System.Drawing.Point(97, 9);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.ReadOnly = true;
            this.LoginBox.Size = new System.Drawing.Size(241, 13);
            this.LoginBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пользователь:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Укажите путь к файлу";
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(153, 83);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(473, 20);
            this.PathBox.TabIndex = 2;
            // 
            // LoadFile
            // 
            this.LoadFile.Location = new System.Drawing.Point(512, 109);
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.Size = new System.Drawing.Size(114, 31);
            this.LoadFile.TabIndex = 3;
            this.LoadFile.Text = "Обзор...";
            this.LoadFile.UseVisualStyleBackColor = true;
            this.LoadFile.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // bSigh
            // 
            this.bSigh.Location = new System.Drawing.Point(493, 160);
            this.bSigh.Name = "bSigh";
            this.bSigh.Size = new System.Drawing.Size(133, 47);
            this.bSigh.TabIndex = 4;
            this.bSigh.Text = "Подписать ";
            this.bSigh.UseVisualStyleBackColor = true;
            this.bSigh.Click += new System.EventHandler(this.button1_Click);
            // 
            // bCheckSign
            // 
            this.bCheckSign.Location = new System.Drawing.Point(493, 236);
            this.bCheckSign.Name = "bCheckSign";
            this.bCheckSign.Size = new System.Drawing.Size(133, 47);
            this.bCheckSign.TabIndex = 5;
            this.bCheckSign.Text = "Проверить ЦП";
            this.bCheckSign.UseVisualStyleBackColor = true;
            this.bCheckSign.Click += new System.EventHandler(this.bCheckSign_Click);
            // 
            // ViewSign
            // 
            this.ViewSign.Location = new System.Drawing.Point(22, 179);
            this.ViewSign.Name = "ViewSign";
            this.ViewSign.Size = new System.Drawing.Size(112, 34);
            this.ViewSign.TabIndex = 6;
            this.ViewSign.Text = "Просмотреть файл";
            this.ViewSign.UseVisualStyleBackColor = true;
            this.ViewSign.Click += new System.EventHandler(this.ViewSign_Click);
            // 
            // Signtb
            // 
            this.Signtb.Location = new System.Drawing.Point(140, 118);
            this.Signtb.Multiline = true;
            this.Signtb.Name = "Signtb";
            this.Signtb.ReadOnly = true;
            this.Signtb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Signtb.Size = new System.Drawing.Size(333, 165);
            this.Signtb.TabIndex = 7;
            // 
            // GetPublicKey
            // 
            this.GetPublicKey.Location = new System.Drawing.Point(22, 219);
            this.GetPublicKey.Name = "GetPublicKey";
            this.GetPublicKey.Size = new System.Drawing.Size(112, 29);
            this.GetPublicKey.TabIndex = 8;
            this.GetPublicKey.Text = "Получить ключ";
            this.GetPublicKey.UseVisualStyleBackColor = true;
            this.GetPublicKey.Click += new System.EventHandler(this.GetPublicKey_Click);
            // 
            // ClearB
            // 
            this.ClearB.Location = new System.Drawing.Point(22, 254);
            this.ClearB.Name = "ClearB";
            this.ClearB.Size = new System.Drawing.Size(112, 29);
            this.ClearB.TabIndex = 9;
            this.ClearB.Text = "Очистить";
            this.ClearB.UseVisualStyleBackColor = true;
            this.ClearB.Click += new System.EventHandler(this.ClearB_Click);
            // 
            // cbFiles
            // 
            this.cbFiles.FormattingEnabled = true;
            this.cbFiles.Location = new System.Drawing.Point(387, 29);
            this.cbFiles.Name = "cbFiles";
            this.cbFiles.Size = new System.Drawing.Size(230, 21);
            this.cbFiles.TabIndex = 10;
            this.cbFiles.Text = "Ваши подисанные файлы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Выберите подписанный файл";
            // 
            // fGetSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 295);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFiles);
            this.Controls.Add(this.ClearB);
            this.Controls.Add(this.GetPublicKey);
            this.Controls.Add(this.Signtb);
            this.Controls.Add(this.ViewSign);
            this.Controls.Add(this.bCheckSign);
            this.Controls.Add(this.bSigh);
            this.Controls.Add(this.LoadFile);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "fGetSign";
            this.Text = "Клиент сервера цифровой подписи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fGetSign_FormClosing);
            this.Load += new System.EventHandler(this.fGetSign_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bLogOut;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button LoadFile;
        private System.Windows.Forms.Button bSigh;
        private System.Windows.Forms.Button bCheckSign;
        private System.Windows.Forms.Button ViewSign;
        private System.Windows.Forms.TextBox Signtb;
        private System.Windows.Forms.Button GetPublicKey;
        private System.Windows.Forms.Button ClearB;
        private System.Windows.Forms.ComboBox cbFiles;
        private System.Windows.Forms.Label label3;
    }
}