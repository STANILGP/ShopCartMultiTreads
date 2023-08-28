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
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.SetLogLevel(LogLevel.Debug);
            IApplication app = new Application();
            ShopServer server = new ShopServer();
            server.StartServer();
            Console.CancelKeyPress += delegate (object? sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                app.Exit();
                server.StopServer();
            };
           

        }
    }
}
