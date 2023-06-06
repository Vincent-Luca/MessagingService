using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Messing_Service | Server";

            Console.WriteLine($"Starting server application now (v{ServerMain.Version})");
            ServerMain main = ServerMain.CreateOrGetInstance();
        }
    }
}
