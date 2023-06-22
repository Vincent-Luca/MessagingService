﻿using Client.Helpers;
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

        private List<UserData> _friendlist = new List<UserData>();
        public List<UserData> Friendlist => _friendlist;

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

        private void button2_Click(object sender, EventArgs e)
        {
            safeexit = true;
            Close();
        }
    }
}
