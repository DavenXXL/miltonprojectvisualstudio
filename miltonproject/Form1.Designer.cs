namespace miltonproject
{
    partial class Form1
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
            this.button_login = new System.Windows.Forms.Button();
            this.label_version = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.button_close = new System.Windows.Forms.Button();
            this.listBox_profiles = new System.Windows.Forms.ListBox();
            this.button_modify = new System.Windows.Forms.Button();
            this.button_reload = new System.Windows.Forms.Button();
            this.button_new = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(11, 12);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(114, 60);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(142, 30);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(127, 25);
            this.label_version.TabIndex = 7;
            this.label_version.Text = "label_version";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(11, 76);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(485, 476);
            this.panel.TabIndex = 8;
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(389, 12);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(109, 60);
            this.button_close.TabIndex = 9;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // listBox_profiles
            // 
            this.listBox_profiles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBox_profiles.FormattingEnabled = true;
            this.listBox_profiles.ItemHeight = 24;
            this.listBox_profiles.Location = new System.Drawing.Point(15, 684);
            this.listBox_profiles.Name = "listBox_profiles";
            this.listBox_profiles.Size = new System.Drawing.Size(482, 124);
            this.listBox_profiles.TabIndex = 10;
            // 
            // button_modify
            // 
            this.button_modify.Location = new System.Drawing.Point(352, 590);
            this.button_modify.Name = "button_modify";
            this.button_modify.Size = new System.Drawing.Size(143, 60);
            this.button_modify.TabIndex = 11;
            this.button_modify.Text = "Modify";
            this.button_modify.UseVisualStyleBackColor = true;
            this.button_modify.Click += new System.EventHandler(this.button_modify_Click);
            // 
            // button_reload
            // 
            this.button_reload.Location = new System.Drawing.Point(16, 590);
            this.button_reload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(143, 60);
            this.button_reload.TabIndex = 0;
            this.button_reload.Text = "Reload";
            this.button_reload.UseVisualStyleBackColor = true;
            this.button_reload.Click += new System.EventHandler(this.button_reload_Click);
            // 
            // button_new
            // 
            this.button_new.Location = new System.Drawing.Point(185, 590);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(138, 60);
            this.button_new.TabIndex = 12;
            this.button_new.Text = "New";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button_new_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 816);
            this.Controls.Add(this.button_new);
            this.Controls.Add(this.button_reload);
            this.Controls.Add(this.button_modify);
            this.Controls.Add(this.listBox_profiles);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.button_login);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.ListBox listBox_profiles;
        private System.Windows.Forms.Button button_modify;
        private System.Windows.Forms.Button button_reload;
        private System.Windows.Forms.Button button_new;
    }
}

