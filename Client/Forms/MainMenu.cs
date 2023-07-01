using Client.Helpers;
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
    public partial class MainMenu : Form
    {
        private static MainMenu _instance;
        public static MainMenu Instance => _instance;

        private List<FriendsData> _friendlist = new List<FriendsData>();
        public List<FriendsData> Friendlist => _friendlist;

        private bool safeexit = false;

        public MainMenu()
        {
            InitializeComponent();
            _instance = this;
            ClientApp.Instance.ConnectionManager.Write($"LoadFriendsList/{ClientApp.Instance.UserData.UserID}",ClientApp.Instance.Client.TcpClient);
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!safeexit)
                Application.Exit();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            safeexit = true;
            Close();
        }

        private void btn_addfriend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_addfriend.Text))
            {
                return;
            }

            ClientApp.Instance.ConnectionManager.Write($"", ClientApp.Instance.Client.TcpClient);
        }
    }
}
