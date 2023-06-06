using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using SimpleTCP;
using SimpleTCP.Server;
using Server.Helpers;

namespace Server
{
    public class ServerMain
    {
        private static ServerMain _instance;
        public static ServerMain Instance => _instance;

        private static DBConnection _dbConnection;
        public static DBConnection DBConnection => _dbConnection;

        public const string Version = "0.1.1";

        private static SimpleTcpServer _server;

        public static SimpleTcpServer Server => _server;

        private static ConnectionManager _connectionManaging;
        public static ConnectionManager ConnectionManaging => _connectionManaging;

        private static List<Client> _clients;
        public static List<Client> clients => _clients;

        private static MessageManager _messageManager;
        public static MessageManager MessageManager => _messageManager;

        public const int port = 8888;

        public ServerMain()
        {
            _server = new SimpleTcpServer();

            _connectionManaging = new ConnectionManager();

            _messageManager = new MessageManager();

            _dbConnection = new DBConnection("Data Source=localhost;Initial Catalog=Messsaging_Service;Persist Security Info=True;User ID=sa;Password=supersecretpassword");

            _clients = new List<Client>();

            _server.ClientConnected += Server_ClientConnected;

            _server.ClientDisconnected += Server_ClientDisconnected;

            _server.DataReceived += Server_DataReceived;

            _server.Delimiter = 0x13;
            _server.StringEncoder = Encoding.UTF8;

            _server.Start(port);

            Console.WriteLine("Server started. Listening for incoming connections on port " + port);
            Console.ReadLine();

            stop();
        }

        public void stop()
        {
            _server.Stop();
        }

        static void Server_DataReceived(object sender, Message e)
        {
            string receivedMessage = e.MessageString;
            Console.WriteLine("Received message: " + receivedMessage);

            string[] MessageParts = receivedMessage.Split('/');

            switch (MessageParts[0]) 
            {
                case "Message":
                    _messageManager.MessageFromTo(MessageParts);
                    break;

                default:
                    break;
            }
        }

        static void Server_ClientConnected(object sender, TcpClient e)
        {
            Console.WriteLine("Client connected: " + e.Client.RemoteEndPoint);

            _connectionManaging.Write($"ConnectionConfirmation/{e.Client.RemoteEndPoint}",e);

            Client client = new Client();
            client.ConnectionState = ConnectionStateClient.Connected;
            client._client = e;
            client.RemoteEndPoint = e.Client.RemoteEndPoint.ToString();
            _clients.Add(client);
        }

        static void Server_ClientDisconnected(object sender, TcpClient e)
        {
            Console.WriteLine("Client disconnected: " + e.Client.RemoteEndPoint);

            _clients.Remove(_clients.Find(x => x.RemoteEndPoint == e.Client.RemoteEndPoint.ToString()));
        }

        public static ServerMain CreateOrGetInstance()
        {
            return _instance != null ? _instance : new ServerMain();
        }
    }
}
