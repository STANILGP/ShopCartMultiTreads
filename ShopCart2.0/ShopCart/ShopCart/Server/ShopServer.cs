using ShopCart.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Server
{
    internal class ShopServer
    {  
        static private IPAddress IP = IPAddress.Parse("0.0.0.0");
        static private int port = 12345;
        static private TcpListener listener = new TcpListener(IP, port); 
        TcpClient client;
        public void StartServer()
        {
            listener.Start();
            Console.WriteLine("Server is listening...");
            client = listener.AcceptTcpClient();
        }
        public string ComWithClient()
        {
            while (client != null)
            {
                NetworkStream stream = client.GetStream();
                ProtocolParser parser = new ProtocolParser();
                Console.WriteLine("Client connected");
                return parser.sProtocolParser(stream);
            }
           

        }
        public void StopServer() 
        {
            client.Close();
            listener.Stop();
        }
    }
}
