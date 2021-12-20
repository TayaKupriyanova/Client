namespace Client
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PasswBox = new System.Windows.Forms.TextBox();
            this.AuthorButton = new System.Windows.Forms.Button();
            this.RegistrButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Чтобы продолжить, необходимо авторизироваться";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль";
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(90, 82);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(209, 20);
            this.LoginBox.TabIndex = 3;
            // 
            // PasswBox
            // 
            this.PasswBox.Location = new System.Drawing.Point(90, 124);
            this.PasswBox.Name = "PasswBox";
            this.PasswBox.Size = new System.Drawing.Size(209, 20);
            this.PasswBox.TabIndex = 4;
            this.PasswBox.UseSystemPasswordChar = true;
            // 
            // AuthorButton
            // 
            this.AuthorButton.Location = new System.Drawing.Point(393, 85);
            this.AuthorButton.Name = "AuthorButton";
            this.AuthorButton.Size = new System.Drawing.Size(141, 55);
            this.AuthorButton.TabIndex = 5;
            this.AuthorButton.Text = "Войти";
            this.AuthorButton.UseVisualStyleBackColor = true;
            this.AuthorButton.Click += new System.EventHandler(this.AuthorButton_Click);
            // 
            // RegistrButton
            // 
            this.RegistrButton.Location = new System.Drawing.Point(393, 155);
            this.RegistrButton.Name = "RegistrButton";
            this.RegistrButton.Size = new System.Drawing.Size(141, 41);
            this.RegistrButton.TabIndex = 6;
            this.RegistrButton.Text = "Зарегистрироваться";
            this.RegistrButton.UseVisualStyleBackColor = true;
            this.RegistrButton.Click += new System.EventHandler(this.RegistrButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 279);
            this.Controls.Add(this.RegistrButton);
            this.Controls.Add(this.AuthorButton);
            this.Controls.Add(this.PasswBox);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Клиент сервиса цифровой подписи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.TextBox PasswBox;
        private System.Windows.Forms.Button AuthorButton;
        private System.Windows.Forms.Button RegistrButton;
    }
}