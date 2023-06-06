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
    public partial class Form1 : Form
    {
        SimpleTcpClient client = new SimpleTcpClient();
        public Form1()
        {
            InitializeComponent();
            
            client.StringEncoder = Encoding.UTF8;

            int serverPort = 8888; // Replace with the server port
            string serverIP = "127.0.0.1"; // Replace with the server IP address

            client.Connect(serverIP, serverPort);

            MessageBox.Show("Connected to server at " + serverIP + ":" + serverPort);

            client.DataReceived += Client_DataReceived;

            
        }
        static void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            var receivedMessage = e.MessageString;
            MessageBox.Show("Received message: " + receivedMessage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.WriteLine(textBox1.Text);
        }
    }
}
