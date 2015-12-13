using System;
using GodLib.Web;

namespace Problem.B
{
    class Program
    {
        static void Main(string[] args)
        {
            int port;
            string portStr = Console.ReadLine();
            int.TryParse(portStr, out port);

            var httpServer = new HttpServer("http://127.0.0.1", port, new ClientProcessor());
            httpServer.Start();
        }
    }
}
