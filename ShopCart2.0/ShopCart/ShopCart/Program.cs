using ShopCart.Server;
using ShopCart.Service;
using ShopCart.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logger.SetLogLevel(LogLevel.Debug);
            ShopServer server = new ShopServer();
            Console.CancelKeyPress += delegate (object? sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                server.StopServer();
                Environment.Exit(0);
            };
           server.StartServer();

        }
    }
}
