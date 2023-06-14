using Client.Helpers;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class ClientApp
    {
        private static SimpleTcpClient _client = new SimpleTcpClient();
        public SimpleTcpClient Client => Client;

        private ClientApp _instance;
        public ClientApp Instance => _instance;

        private static UserData _userData;
        public static UserData UserData => _userData;

        private MessageHandler _messageHandler;
        public MessageHandler MessageHandler => _messageHandler;

        private ConnectionManager _connectionManager;
        public ConnectionManager ConnectionManager => _connectionManager;

        public ClientApp() 
        {
            if (_instance != null)
                return;

            _instance = this;

            _userData = new UserData();
            _messageHandler = new MessageHandler();
            _connectionManager = new ConnectionManager();

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

            Application.ApplicationExit += (sender, args) =>
            {
                _client.Disconnect();
                _client = null;
                Environment.Exit(0);
            };

            _client.DataReceived += Client_DataReceived;

        }
        static void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            string receivedMessage = e.MessageString;

            string[] Messageparts = e.MessageString.Split('/');

            switch (Messageparts[0])
            {
                case "ConnectionConfirmation":
                    _userData.RemoteEndPoint = Messageparts[1];
                    break;

                case "LoginFailure":

                    if (Messageparts[1] == "No_Account_with_this_Username_or_Password")
                    {
                        MessageBox.Show("No Account with this Username and Password found, please try again");
                    }
                    break;

                case "LoginSuccess":
                    _userData.UserID = int.Parse(Messageparts[1]);
                    break;

                case "CreateAccountFailure":
                    if (Messageparts[1] == "Account_with_this_Username_already_exists")
                    {
                        MessageBox.Show("Account with this Username already exists, please choose something else");
                    }
                    break;

                default:
                    break;
            }

            MessageBox.Show("Received message: " + receivedMessage);
        }
    }
}
