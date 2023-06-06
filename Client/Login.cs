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
        private static SimpleTcpClient _client = new SimpleTcpClient();
        public static SimpleTcpClient Client => _client;
        private static Login _instance;
        public static Login Instance => _instance;

        private static string RemoteEndPoint;

        public Login()
        {
            InitializeComponent();

            _instance = this;

            _client.StringEncoder = Encoding.UTF8;

            int serverPort = 8888;
            string serverIP = "127.0.0.1";

            try
            {
                _client.Connect(serverIP, serverPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
            _client.DataReceived += Client_DataReceived;

            
        }
        static void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            var receivedMessage = e.MessageString;

            string[] parts = e.MessageString.Split('/');


            switch (parts[0])
            {
                case "ConnectionConfirmation":
                    RemoteEndPoint = parts[1];
                    break;

                default:
                    break;
            }

            MessageBox.Show("Received message: " + receivedMessage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _client.Write(textBox1.Text);
        }
    }
}
