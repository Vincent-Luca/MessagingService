using System;
using System.Net.Sockets;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        private static async Task HandleClient(TcpClient tcpClient)
        {
            var webSocketContext = await GetWebSocketContext(tcpClient);
            if (webSocketContext == null)
            {
                // Failed to establish WebSocket connection
                return;
            }

            var webSocket = webSocketContext.WebSocket;
            var buffer = new byte[1024];

            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    }
                    else
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);

                        // Handle the received message and update the database as needed
                        Console.WriteLine($"Received message: {message}");

                        // Send a response back to the client
                        var response = $"Server received: {message}";
                        var responseBytes = Encoding.UTF8.GetBytes(response);
                        await webSocket.SendAsync(new ArraySegment<byte>(responseBytes), WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
            }
            catch (WebSocketException)
            {
                // Handle any WebSocket-specific exceptions here
            }
            finally
            {
                // Clean up resources
                webSocket?.Dispose();
                tcpClient?.Dispose();
            }
        }

        private static async Task<WebSocketContext> GetWebSocketContext(TcpClient tcpClient)
        {
            var stream = tcpClient.GetStream();
            var webSocketOptions = new WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(120) };

            if (!stream.CanRead || !stream.CanWrite)
            {
                return null;
            }

            var context = System.Net.WebSockets.WebSocketContext;
            return context;
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
