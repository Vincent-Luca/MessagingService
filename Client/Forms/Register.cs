using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class Register : Form
    {
        private static Register _instance;
        public static Register Instance => _instance;


        public Register()
        {
            InitializeComponent();
            _instance = this;
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_username.Text)|| string.IsNullOrEmpty(txt_displayname.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_pass.Text) || string.IsNullOrEmpty(txt_confirmpass.Text))
            {
                MessageBox.Show("Please fill out ever space");
                return;
            }
            if (txt_pass.Text != txt_confirmpass.Text)
            {
                MessageBox.Show("The entered Passwords don't match up");
                return;
            }

            ClientApp.Instance.ConnectionManager.Write($"CreateUser/{txt_username.Text}/{txt_displayname.Text}/{txt_email.Text}/{ClientApp.Instance.Encryption.Hash(txt_pass.Text)}", ClientApp.Instance.Client.TcpClient);
        }

        private void btn_passShow_Click(object sender, EventArgs e)
        {
            txt_pass.UseSystemPasswordChar = !txt_pass.UseSystemPasswordChar;
        }

        private void btn_PassConfirmShow_Click(object sender, EventArgs e)
        {
            txt_confirmpass.UseSystemPasswordChar = !txt_confirmpass.UseSystemPasswordChar;
        }

        public void ConfirmCreateAccount()
        {
            MessageBox.Show("Account was succesfully created, please log in to finalize!");
            Close();
        }

        public void Failure()
        {
            txt_username.Text = "";
            txt_pass.Text = "";
            txt_confirmpass.Text = "";
            txt_confirmpass.UseSystemPasswordChar = true;
            txt_confirmpass.UseSystemPasswordChar = true;
        }
    }
}
