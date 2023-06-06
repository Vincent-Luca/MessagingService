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

namespace Server.Helpers
{
    public class Client
    {
        public string RemoteEndPoint;
        public TcpClient _client;
        public int Port => Convert.ToInt32(RemoteEndPoint.Split(':')[1]);
        public string IP => RemoteEndPoint.Split(':')[0];
        public int UserID;
        public ConnectionStateClient ConnectionState;

        public Client()
        {

        }
    }

    public enum ConnectionStateClient
    {
        Connected = 0,
        LoggedIn = 1
    }
}
