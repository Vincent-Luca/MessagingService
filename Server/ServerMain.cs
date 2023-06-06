using System;
using System.Net.Sockets;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Server
{
    public class ServerMain
    {
        private static ServerMain _instance;
        public static ServerMain Instance => _instance;

        public const string Version = "0.1.1";


        public ServerMain()
        {

        }

        static void Start()
        {
            const int port = 8888;
            var tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            Console.WriteLine($"Server listening on port {port}...");

            while (true)
            {
                var tcpClient = tcpListener.AcceptTcpClient();
                _ = Task.Run(() => HandleClient(tcpClient));
            }
        }
        public static ServerMain CreateOrGetInstance()
        {
            return _instance != null ? _instance : new ServerMain();
        }
    }
}
