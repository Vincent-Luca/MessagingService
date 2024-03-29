﻿namespace Client.Forms
{
    partial class MainMenu
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
            this.pan_friendlist = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_addfriend = new System.Windows.Forms.Button();
            this.txt_addfriend = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_friendlist
            // 
            this.pan_friendlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pan_friendlist.AutoScroll = true;
            this.pan_friendlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_friendlist.Location = new System.Drawing.Point(0, 0);
            this.pan_friendlist.Name = "pan_friendlist";
            this.pan_friendlist.Size = new System.Drawing.Size(154, 454);
            this.pan_friendlist.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_logout);
            this.panel1.Controls.Add(this.btn_addfriend);
            this.panel1.Controls.Add(this.txt_addfriend);
            this.panel1.Location = new System.Drawing.Point(154, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 68);
            this.panel1.TabIndex = 1;
            // 
            // btn_logout
            // 
            this.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_logout.Location = new System.Drawing.Point(495, 3);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(138, 28);
            this.btn_logout.TabIndex = 3;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_addfriend
            // 
            this.btn_addfriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addfriend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_addfriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addfriend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_addfriend.Location = new System.Drawing.Point(5, 29);
            this.btn_addfriend.Name = "btn_addfriend";
            this.btn_addfriend.Size = new System.Drawing.Size(138, 28);
            this.btn_addfriend.TabIndex = 2;
            this.btn_addfriend.Text = "Add Friend";
            this.btn_addfriend.UseVisualStyleBackColor = true;
            this.btn_addfriend.Click += new System.EventHandler(this.btn_addfriend_Click);
            // 
            // txt_addfriend
            // 
            this.txt_addfriend.BackColor = System.Drawing.Color.Gray;
            this.txt_addfriend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_addfriend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_addfriend.Location = new System.Drawing.Point(5, 3);
            this.txt_addfriend.Name = "txt_addfriend";
            this.txt_addfriend.Size = new System.Drawing.Size(138, 20);
            this.txt_addfriend.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(39)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_friendlist);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_friendlist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_addfriend;
        private System.Windows.Forms.Button btn_addfriend;
        private System.Windows.Forms.Button btn_logout;
    }
}