namespace Client
{
    partial class Login
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_reg = new System.Windows.Forms.Button();
            this.lbl_forgotpass = new System.Windows.Forms.Label();
            this.chk_remember = new System.Windows.Forms.CheckBox();
            this.btn_passShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.Gray;
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_username.Location = new System.Drawing.Point(95, 52);
            this.txt_username.Margin = new System.Windows.Forms.Padding(7);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(168, 20);
            this.txt_username.TabIndex = 0;
            // 
            // txt_pass
            // 
            this.txt_pass.BackColor = System.Drawing.Color.Gray;
            this.txt_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_pass.Location = new System.Drawing.Point(95, 111);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(7);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(168, 20);
            this.txt_pass.TabIndex = 1;
            this.txt_pass.UseSystemPasswordChar = true;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.BackColor = System.Drawing.Color.Transparent;
            this.lbl_username.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_username.Location = new System.Drawing.Point(90, 20);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(106, 25);
            this.lbl_username.TabIndex = 2;
            this.lbl_username.Text = "Username:";
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pass.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_pass.Location = new System.Drawing.Point(94, 79);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(102, 25);
            this.lbl_pass.TabIndex = 3;
            this.lbl_pass.Text = "Password:";
            // 
            // btn_login
            // 
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_login.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_login.Location = new System.Drawing.Point(95, 187);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(168, 33);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_reg
            // 
            this.btn_reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_reg.Location = new System.Drawing.Point(95, 226);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(168, 33);
            this.btn_reg.TabIndex = 5;
            this.btn_reg.Text = "Register";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // lbl_forgotpass
            // 
            this.lbl_forgotpass.AutoSize = true;
            this.lbl_forgotpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_forgotpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_forgotpass.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_forgotpass.ForeColor = System.Drawing.Color.Cyan;
            this.lbl_forgotpass.Location = new System.Drawing.Point(94, 134);
            this.lbl_forgotpass.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.lbl_forgotpass.Name = "lbl_forgotpass";
            this.lbl_forgotpass.Size = new System.Drawing.Size(169, 21);
            this.lbl_forgotpass.TabIndex = 6;
            this.lbl_forgotpass.Text = "Forgot your password?";
            this.lbl_forgotpass.Click += new System.EventHandler(this.lbl_forgotpass_Click);
            // 
            // chk_remember
            // 
            this.chk_remember.AutoSize = true;
            this.chk_remember.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_remember.Location = new System.Drawing.Point(98, 160);
            this.chk_remember.Name = "chk_remember";
            this.chk_remember.Size = new System.Drawing.Size(120, 21);
            this.chk_remember.TabIndex = 7;
            this.chk_remember.Text = "Remember Me?";
            this.chk_remember.UseVisualStyleBackColor = true;
            // 
            // btn_passShow
            // 
            this.btn_passShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_passShow.BackgroundImage")));
            this.btn_passShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_passShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_passShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_passShow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_passShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_passShow.Location = new System.Drawing.Point(269, 111);
            this.btn_passShow.Name = "btn_passShow";
            this.btn_passShow.Size = new System.Drawing.Size(25, 20);
            this.btn_passShow.TabIndex = 21;
            this.btn_passShow.UseVisualStyleBackColor = true;
            this.btn_passShow.Click += new System.EventHandler(this.btn_passShow_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(364, 302);
            this.Controls.Add(this.btn_passShow);
            this.Controls.Add(this.chk_remember);
            this.Controls.Add(this.lbl_forgotpass);
            this.Controls.Add(this.btn_reg);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lbl_pass);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_username);
            this.MaximumSize = new System.Drawing.Size(380, 341);
            this.MinimumSize = new System.Drawing.Size(380, 341);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.Label lbl_forgotpass;
        private System.Windows.Forms.CheckBox chk_remember;
        private System.Windows.Forms.Button btn_passShow;
    }
}

