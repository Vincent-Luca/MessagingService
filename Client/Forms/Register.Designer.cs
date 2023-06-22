namespace Client.Forms
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.btn_reg = new System.Windows.Forms.Button();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.lbl_confirmpass = new System.Windows.Forms.Label();
            this.txt_confirmpass = new System.Windows.Forms.TextBox();
            this.lbl_displayname = new System.Windows.Forms.Label();
            this.txt_displayname = new System.Windows.Forms.TextBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.btn_passShow = new System.Windows.Forms.Button();
            this.btn_PassConfirmShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_reg
            // 
            this.btn_reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_reg.Location = new System.Drawing.Point(100, 344);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(168, 33);
            this.btn_reg.TabIndex = 13;
            this.btn_reg.Text = "Register";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(39)))), ((int)(((byte)(52)))));
            this.lbl_pass.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lbl_pass.Location = new System.Drawing.Point(95, 209);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(102, 25);
            this.lbl_pass.TabIndex = 11;
            this.lbl_pass.Text = "Password:";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(39)))), ((int)(((byte)(52)))));
            this.lbl_username.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lbl_username.Location = new System.Drawing.Point(95, 14);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(106, 25);
            this.lbl_username.TabIndex = 10;
            this.lbl_username.Text = "Username:";
            // 
            // txt_pass
            // 
            this.txt_pass.BackColor = System.Drawing.Color.Gray;
            this.txt_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_pass.Location = new System.Drawing.Point(100, 241);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(7);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(168, 26);
            this.txt_pass.TabIndex = 9;
            this.txt_pass.UseSystemPasswordChar = true;
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.Gray;
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_username.Location = new System.Drawing.Point(100, 46);
            this.txt_username.Margin = new System.Windows.Forms.Padding(7);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(168, 26);
            this.txt_username.TabIndex = 8;
            // 
            // lbl_confirmpass
            // 
            this.lbl_confirmpass.AutoSize = true;
            this.lbl_confirmpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(39)))), ((int)(((byte)(52)))));
            this.lbl_confirmpass.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_confirmpass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lbl_confirmpass.Location = new System.Drawing.Point(95, 274);
            this.lbl_confirmpass.Name = "lbl_confirmpass";
            this.lbl_confirmpass.Size = new System.Drawing.Size(180, 25);
            this.lbl_confirmpass.TabIndex = 15;
            this.lbl_confirmpass.Text = "Confirm Password:";
            // 
            // txt_confirmpass
            // 
            this.txt_confirmpass.BackColor = System.Drawing.Color.Gray;
            this.txt_confirmpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_confirmpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_confirmpass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_confirmpass.Location = new System.Drawing.Point(100, 308);
            this.txt_confirmpass.Margin = new System.Windows.Forms.Padding(7);
            this.txt_confirmpass.Name = "txt_confirmpass";
            this.txt_confirmpass.Size = new System.Drawing.Size(168, 26);
            this.txt_confirmpass.TabIndex = 14;
            this.txt_confirmpass.UseSystemPasswordChar = true;
            // 
            // lbl_displayname
            // 
            this.lbl_displayname.AutoSize = true;
            this.lbl_displayname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(39)))), ((int)(((byte)(52)))));
            this.lbl_displayname.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_displayname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lbl_displayname.Location = new System.Drawing.Point(95, 79);
            this.lbl_displayname.Name = "lbl_displayname";
            this.lbl_displayname.Size = new System.Drawing.Size(138, 25);
            this.lbl_displayname.TabIndex = 17;
            this.lbl_displayname.Text = "Display Name:";
            // 
            // txt_displayname
            // 
            this.txt_displayname.BackColor = System.Drawing.Color.Gray;
            this.txt_displayname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_displayname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_displayname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_displayname.Location = new System.Drawing.Point(100, 111);
            this.txt_displayname.Margin = new System.Windows.Forms.Padding(7);
            this.txt_displayname.Name = "txt_displayname";
            this.txt_displayname.Size = new System.Drawing.Size(168, 26);
            this.txt_displayname.TabIndex = 16;
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(39)))), ((int)(((byte)(52)))));
            this.lbl_email.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lbl_email.Location = new System.Drawing.Point(95, 144);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(64, 25);
            this.lbl_email.TabIndex = 19;
            this.lbl_email.Text = "Email:";
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.Gray;
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_email.Location = new System.Drawing.Point(100, 176);
            this.txt_email.Margin = new System.Windows.Forms.Padding(7);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(168, 26);
            this.txt_email.TabIndex = 18;
            // 
            // btn_passShow
            // 
            this.btn_passShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_passShow.BackgroundImage")));
            this.btn_passShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_passShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_passShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_passShow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_passShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_passShow.Location = new System.Drawing.Point(278, 241);
            this.btn_passShow.Name = "btn_passShow";
            this.btn_passShow.Size = new System.Drawing.Size(25, 26);
            this.btn_passShow.TabIndex = 20;
            this.btn_passShow.UseVisualStyleBackColor = true;
            this.btn_passShow.Click += new System.EventHandler(this.btn_passShow_Click);
            // 
            // btn_PassConfirmShow
            // 
            this.btn_PassConfirmShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_PassConfirmShow.BackgroundImage")));
            this.btn_PassConfirmShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_PassConfirmShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PassConfirmShow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_PassConfirmShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_PassConfirmShow.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PassConfirmShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_PassConfirmShow.Location = new System.Drawing.Point(278, 308);
            this.btn_PassConfirmShow.Name = "btn_PassConfirmShow";
            this.btn_PassConfirmShow.Size = new System.Drawing.Size(25, 26);
            this.btn_PassConfirmShow.TabIndex = 21;
            this.btn_PassConfirmShow.UseVisualStyleBackColor = true;
            this.btn_PassConfirmShow.Click += new System.EventHandler(this.btn_PassConfirmShow_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(39)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(391, 406);
            this.Controls.Add(this.btn_PassConfirmShow);
            this.Controls.Add(this.btn_passShow);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.lbl_displayname);
            this.Controls.Add(this.txt_displayname);
            this.Controls.Add(this.lbl_confirmpass);
            this.Controls.Add(this.txt_confirmpass);
            this.Controls.Add(this.btn_reg);
            this.Controls.Add(this.lbl_pass);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_username);
            this.MaximumSize = new System.Drawing.Size(407, 445);
            this.MinimumSize = new System.Drawing.Size(407, 445);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label lbl_confirmpass;
        private System.Windows.Forms.TextBox txt_confirmpass;
        private System.Windows.Forms.Label lbl_displayname;
        private System.Windows.Forms.TextBox txt_displayname;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Button btn_passShow;
        private System.Windows.Forms.Button btn_PassConfirmShow;
    }
}