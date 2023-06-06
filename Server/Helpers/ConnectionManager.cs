using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;
using SimpleTCP.Server;

namespace Server.Helpers
{
    public class ConnectionManager
    {
        public static Encoding StringEncoder = Encoding.UTF8;
        public ConnectionManager() 
        {
        }

        public void Write(byte[] data, TcpClient Client = null)
        {
            if (Client == null)
            {
                throw new Exception("Cannot send data to a null TcpClient (check to see if Connect was called)");
            }

            Client.GetStream().Write(data, 0, data.Length);
        }

        public void Write(string data, TcpClient Client = null)
        {
            if (Client == null)
            {
                throw new Exception("Cannot send data to a null TcpClient (check to see if Connect was called)");
            }
            if (data != null)
            {
                Write(StringEncoder.GetBytes(data), Client);
            }
        }
    }
}
