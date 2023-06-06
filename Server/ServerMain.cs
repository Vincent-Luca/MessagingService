using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleTCP;
using SimpleTCP.Server;

namespace Server
{
    public class ServerMain
    {
        private static ServerMain _instance;
        public static ServerMain Instance => _instance;

        public const string Version = "0.1.1";

        private SimpleTcpServer _server;

        public SimpleTcpServer Server => _server;

        private static Dictionary<string, SimpleTcpClient> _clients;
        public static Dictionary<string, SimpleTcpClient> clients => _clients;


        public ServerMain()
        {
            _server = new SimpleTcpServer();

            _clients = new Dictionary<string, SimpleTcpClient>();

            _server.ClientConnected += Server_ClientConnected;

            _server.ClientDisconnected += Server_ClientConnected;

            _server.DataReceived += Server_DataReceived;

            _server.Delimiter = 0x13; // Message delimiter
            _server.StringEncoder = Encoding.UTF8;

            int port = 8888; // Replace with the desired server port
            _server.Start(port);

            Console.WriteLine("Server started. Listening for incoming connections on port " + port);
            Console.ReadLine();

            _server.Stop();
        }

        public void start()
        {
            
        }

        public void stop()
        {

        }

        static void Server_DataReceived(object sender, Message e)
        {
            var receivedMessage = e.MessageString;
            Console.WriteLine("Received message: " + receivedMessage);

            // Process and handle the received message

            // Example: Sending a message to a specific client
            if (receivedMessage.StartsWith("@"))
            {
                string[] parts = receivedMessage.Split(new[] { ' ' }, 2);
                if (parts.Length == 2)
                {
                    string clientId = parts[0].Substring(1);
                    string message = parts[1];

                    if (clients.TryGetValue(clientId, out var client))
                    {
                        client.Write(message);
                    }
                    else
                    {
                        Console.WriteLine("Client not found: " + clientId);
                    }
                }
            }
            else
            {
                // Echo the message back to all clients
                foreach (var client in clients.Values)
                {
                    client.Write(receivedMessage);
                }
            }
        }

        static void Server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            Console.WriteLine("Client connected: " + e.Client.RemoteEndPoint);

            // Create a new SimpleTcpClient for the connected client and add it to the clients dictionary
            var client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;

            clients.Add(e.Client.RemoteEndPoint.ToString(), client);

        }

        static void Server_ClientDisconnected(object sender, System.Net.Sockets.TcpClient e)
        {
            Console.WriteLine("Client disconnected: " + e.Client.RemoteEndPoint);

            // Remove the SimpleTcpClient for the disconnected client from the clients dictionary
            clients.Remove(e.Client.RemoteEndPoint.ToString());
        }

        public static ServerMain CreateOrGetInstance()
        {
            return _instance != null ? _instance : new ServerMain();
        }
    }
}
