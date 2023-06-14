using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Login : Form
    {
        private static Login _instance = new Login();
        public static Login Instance => _instance;
        public Login()
        {
            InitializeComponent();
        }
    }
}
