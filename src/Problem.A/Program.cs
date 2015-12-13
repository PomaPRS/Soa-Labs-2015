using System;
using System.Net;
using System.Text;
using GodLib.Adapters;
using GodLib.Entities;
using GodLib.Serializers;
using GodLib.Web;

namespace Problem.A
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int port;
            var portStr = Console.ReadLine();
            if (!int.TryParse(portStr, out port))
                return;

            var settings = new HttpMessengerSettings()
            {
                Host = "http://127.0.0.1",
                Port = port
            };
            var httpMessenger = new HttpMessenger(settings);
            while (httpMessenger.SendGet("Ping").StatusCode != HttpStatusCode.OK)
            {
            }

            var response = httpMessenger.SendGet("GetInputData");
            var adapter = new JsonIOAdapter(new IOAdapter());
            var answer = adapter.Convert(response.Data);

            httpMessenger.SendPost("WriteAnswer", Encoding.UTF8.GetBytes(answer));
        }
    }
}