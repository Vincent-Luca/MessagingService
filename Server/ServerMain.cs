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

        private DBConnection _dbConnection;
        public DBConnection DBConnection => _dbConnection;

        public const string Version = "0.1.1";

        private SimpleTcpServer _server;

        public SimpleTcpServer Server => _server;

        private ConnectionManager _connectionManaging;
        public ConnectionManager ConnectionManaging => _connectionManaging;

        private List<Client> _clients;
        public List<Client> clients => _clients;

        private MessageManager _messageManager;
        public MessageManager MessageManager => _messageManager;

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

            Thread debugThread = new Thread(() => debug());
            debugThread.Start();
        }

        public void debug()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Please write a debug command:");
                string input = Console.ReadLine();

                string[] inputpart = input.Split(' ');

                switch (inputpart[0].ToLower())
                {
                    case "stop":
                        loop = false;
                        break;

                    case "Show":
                        if (inputpart.Length == 1)
                        {
                            Console.WriteLine("Please finish your command");
                            break;
                        }
                        switch (inputpart[1])
                        {
                            default:
                                break;
                        }
                        break;
                }
            }

            stop();
        }

        public void stop()
        {
            _server.Stop();
            Environment.Exit(0);
        }

        private void Server_DataReceived(object sender, Message e)
        {
            string receivedMessage = e.MessageString;
            Console.WriteLine("Received message: " + receivedMessage);

            string[] MessageParts = receivedMessage.Split('/');

            switch (MessageParts[0]) 
            {
                case "Login":
                    Thread Login = new Thread(() => _messageManager.Login(MessageParts));
                    Login.Start();
                    break;
                case "CreateUser:":
                    Thread CreateUser = new Thread(() => _messageManager.CreateUser(MessageParts));
                    CreateUser.Start();
                    break;
                case "TextMessage":
                    Thread TextMessage = new Thread(() => _messageManager.TextMessage(MessageParts));
                    TextMessage.Start();
                    break;
                case "AudioMessage:":
                    Thread AudioMessage = new Thread(() => _messageManager.AudioMessage(MessageParts));
                    AudioMessage.Start();
                    break;
                case "VideoMessage:":
                    Thread VideoMessage = new Thread(() => _messageManager.VideoMessage(MessageParts));
                    VideoMessage.Start();
                    break;
                case "SendFriendRequest:":
                    Thread SendFriendRequest = new Thread(() => _messageManager.SendFriendRequest(MessageParts));
                    SendFriendRequest.Start();
                    break;
                case "AccpetFriendRequest:":
                    Thread AccpetFriendRequest = new Thread(() => _messageManager.AccpetFriendRequest(MessageParts));
                    AccpetFriendRequest.Start();
                    break;
                case "DeclineFriendRequest:":
                    Thread DeclineFriendRequest = new Thread(() => _messageManager.DeclineFriendRequest(MessageParts));
                    DeclineFriendRequest.Start();
                    break;
                case "GroupChatTextMessage:":
                    Thread GroupChatTextMessage = new Thread(() => _messageManager.GroupChatTextMessage(MessageParts));
                    GroupChatTextMessage.Start();
                    break;
                case "GroupChatAudioMessage:":
                    Thread GroupChatAudioMessage = new Thread(() => _messageManager.GroupChatAudioMessage(MessageParts));
                    GroupChatAudioMessage.Start();
                    break;
                case "GroupChatVideoMessage:":
                    Thread GroupChatVideoMessage = new Thread(() => _messageManager.GroupChatVideoMessage(MessageParts));
                    GroupChatVideoMessage.Start();
                    break;
                case "ChatLoadRequest:":
                    Thread ChatLoadRequest = new Thread(() => _messageManager.ChatLoadRequest(MessageParts));
                    ChatLoadRequest.Start();
                    break;

                default:
                    Console.WriteLine($"There has been an error with the following request: {receivedMessage}");
                    break;
            }
        }

        private void Server_ClientConnected(object sender, TcpClient e)
        {
            Console.WriteLine("Client connected: " + e.Client.RemoteEndPoint);

            _connectionManaging.Write($"ConnectionConfirmation/{e.Client.RemoteEndPoint}",e);

            Client client = new Client();
            client.ConnectionState = ConnectionStateClient.Connected;
            client._client = e;
            client.RemoteEndPoint = e.Client.RemoteEndPoint.ToString();
            _clients.Add(client);
        }

        private void Server_ClientDisconnected(object sender, TcpClient e)
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
