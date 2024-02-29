namespace miltonproject
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
            this.label_server = new System.Windows.Forms.Label();
            this.textBox_server = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.maskedTextBox_password = new System.Windows.Forms.MaskedTextBox();
            this.button_logon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_server
            // 
            this.label_server.AutoSize = true;
            this.label_server.Location = new System.Drawing.Point(12, 9);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(147, 25);
            this.label_server.TabIndex = 0;
            this.label_server.Text = "MySql Server:";
            // 
            // textBox_server
            // 
            this.textBox_server.Location = new System.Drawing.Point(12, 49);
            this.textBox_server.Name = "textBox_server";
            this.textBox_server.Size = new System.Drawing.Size(314, 31);
            this.textBox_server.TabIndex = 1;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(12, 99);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(116, 25);
            this.label_username.TabIndex = 2;
            this.label_username.Text = "Username:";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(12, 144);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(314, 31);
            this.textBox_username.TabIndex = 3;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(12, 195);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(112, 25);
            this.label_password.TabIndex = 4;
            this.label_password.Text = "Password:";
            // 
            // maskedTextBox_password
            // 
            this.maskedTextBox_password.Location = new System.Drawing.Point(17, 239);
            this.maskedTextBox_password.Name = "maskedTextBox_password";
            this.maskedTextBox_password.Size = new System.Drawing.Size(309, 31);
            this.maskedTextBox_password.TabIndex = 5;
            // 
            // button_logon
            // 
            this.button_logon.Location = new System.Drawing.Point(344, 49);
            this.button_logon.Name = "button_logon";
            this.button_logon.Size = new System.Drawing.Size(173, 221);
            this.button_logon.TabIndex = 6;
            this.button_logon.Text = "Logon";
            this.button_logon.UseVisualStyleBackColor = true;
            this.button_logon.Click += new System.EventHandler(this.button_logon_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 285);
            this.Controls.Add(this.button_logon);
            this.Controls.Add(this.maskedTextBox_password);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textBox_server);
            this.Controls.Add(this.label_server);
            this.Name = "Form2";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.TextBox textBox_server;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_password;
        private System.Windows.Forms.Button button_logon;
    }
}