using Client.Helpers;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Client
{
    public class ClientApp
    {
        private SimpleTcpClient _client;
        public SimpleTcpClient Client => _client;

        private static ClientApp _instance;
        public static ClientApp Instance => _instance;

        private UserData _userData;
        public UserData UserData => _userData;

        private MessageHandler _messageHandler;
        public MessageHandler MessageHandler => _messageHandler;

        private ConnectionManager _connectionManager;
        public ConnectionManager ConnectionManager => _connectionManager;

        private Encryption _encryption;
        public Encryption Encryption => _encryption;

        private const int serverPort = 8888;
        private const string serverIP = "127.0.0.1";

        public ClientApp() 
        {
            if (_instance != null)
                return;

            _instance = this;

            _encryption = new Encryption();
            _client = new SimpleTcpClient();
            _userData = new UserData();
            _messageHandler = new MessageHandler();
            _connectionManager = new ConnectionManager();

            _client.StringEncoder = Encoding.UTF8;

            try
            {
                _client.Connect(serverIP, serverPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }

            Application.ApplicationExit += (sender, args) =>
            {
                _client.Disconnect();
                _client = null;
                Environment.Exit(0);
            };

            _client.DataReceived += Client_DataReceived;

        }
        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            _messageHandler.MessageManagment(e.MessageString.Split('/'));
        }
    }
}
