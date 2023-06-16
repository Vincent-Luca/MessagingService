using Client.Forms;
using Client.Helpers;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Login : Form
    {
        private static Login _instance;
        public static Login Instance => _instance;
        
        public Login()
        {
            InitializeComponent();
            _instance = this;
        }

        private void lbl_forgotpass_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_username.Text)|| string.IsNullOrEmpty(txt_username.Text))
            {
                MessageBox.Show("Please make sure to enter a Username and password");
                return;
            }
            ClientApp.Instance.ConnectionManager.Write($"Login/{txt_username.Text}/{ClientApp.Instance.Encryption.Hash(txt_pass.Text)}",ClientApp.Instance.Client.TcpClient);
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            Hide();
            reg.ShowDialog();
            Show();
        }

        public void loginconfirmed()
        {
            ClientApp.Instance.UserData.Username = txt_username.Text;
            ClientApp.Instance.UserData.Password = ClientApp.Instance.Encryption.Hash(txt_pass.Text);

            Forms.MainMenu main = new Forms.MainMenu();

            txt_pass.Text = "";
            txt_username.Text = "";

            this.Hide();
            main.ShowDialog();
            this.Show();
        }

        private void btn_passShow_Click(object sender, EventArgs e)
        {
            txt_pass.UseSystemPasswordChar = !txt_pass.UseSystemPasswordChar;
        }
    }
}
