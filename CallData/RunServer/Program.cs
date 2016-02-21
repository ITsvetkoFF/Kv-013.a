using System;
using CallData;
using static System.Net.Dns;

namespace RunServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new SelfHostingServer();
            server.Start();
            Console.WriteLine("Web Api self hosted on " + GetHostByName(GetHostName()).AddressList[0] +
                              ". Hit ENTER to exit...");
            Console.ReadLine();
            server.Stop();
        }
    }
}