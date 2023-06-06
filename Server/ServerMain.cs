using System;
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


        public ServerMain()
        {
            _server = new SimpleTcpServer();

            
        }

        public void start()
        {
            SetUpConDiscon();

        }

        public void stop()
        {

        }

        public void SetUpConDiscon()
        {
            _server.ClientConnected += (sender, e) => Console.WriteLine($"Client ({e.Client.RemoteEndPoint}) connected!");

            _server.ClientDisconnected += (sender, e) => Console.WriteLine($"Client ({e.Client.RemoteEndPoint}) disconnected!");
        }

        private void DataRecivied()
        {
            _server.DataReceived += (sender, e) =>
            {
                var ep = e.TcpClient.Client.RemoteEndPoint;
                var msg = Encoding.UTF8.GetString(e.Data);
                Console.WriteLine($"Received message from {ep}: \"{msg}\"");
                e.Reply(Encoding.UTF8.GetBytes("Hello back!"));
            };
        }


        static void ClientConnected(object sender, ConnectedClient e)
        {
            Console.WriteLine($"Client ({e.Client}) connected!");
        }

        public static ServerMain CreateOrGetInstance()
        {
            return _instance != null ? _instance : new ServerMain();
        }
    }
}
