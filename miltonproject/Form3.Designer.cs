namespace miltonproject
{
    partial class Form3
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
            this.button_apply = new System.Windows.Forms.Button();
            this.panel_current = new System.Windows.Forms.Panel();
            this.panel_new = new System.Windows.Forms.Panel();
            this.button_upload = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(380, 13);
            this.button_apply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(154, 66);
            this.button_apply.TabIndex = 0;
            this.button_apply.Text = "Apply changes";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // panel_current
            // 
            this.panel_current.Location = new System.Drawing.Point(12, 97);
            this.panel_current.Name = "panel_current";
            this.panel_current.Size = new System.Drawing.Size(211, 228);
            this.panel_current.TabIndex = 1;
            // 
            // panel_new
            // 
            this.panel_new.Location = new System.Drawing.Point(316, 97);
            this.panel_new.Name = "panel_new";
            this.panel_new.Size = new System.Drawing.Size(218, 228);
            this.panel_new.TabIndex = 2;
            // 
            // button_upload
            // 
            this.button_upload.Location = new System.Drawing.Point(12, 12);
            this.button_upload.Name = "button_upload";
            this.button_upload.Size = new System.Drawing.Size(154, 66);
            this.button_upload.TabIndex = 3;
            this.button_upload.Text = "Upload";
            this.button_upload.UseVisualStyleBackColor = true;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(12, 369);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(522, 29);
            this.username.TabIndex = 4;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(12, 437);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(522, 29);
            this.password.TabIndex = 5;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(226, 504);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(89, 102);
            this.button_delete.TabIndex = 6;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 628);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.button_upload);
            this.Controls.Add(this.panel_new);
            this.Controls.Add(this.panel_current);
            this.Controls.Add(this.button_apply);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Panel panel_current;
        private System.Windows.Forms.Panel panel_new;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button button_delete;
    }
}