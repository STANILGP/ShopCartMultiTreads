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
        //static private IPAddress IP = IPAddress.Parse("0.0.0.0");
        //static private int port = 12345;
        //static private TcpListener listener = new TcpListener(IP, port); 
        //static TcpClient client;
        //NetworkStream stream;
        //string Line;
        //public void StartServer()
        //{
        //    listener.Start();
        //    Console.WriteLine("Server is listening...");

        //}
        //public string ComWithServer()
        //{
        //    client = listener.AcceptTcpClient();
        //    Console.WriteLine("Client connected");
        //    stream = client.GetStream();
        //    byte[] data = new byte[1024];
        //    int bytesRead = stream.Read(data, 0, data.Length);
        //    string message = Encoding.ASCII.GetString(data, 0, bytesRead);
        //    message = Line; 
        //    return Line;
        //}
        //public void StopServer() 
        //{
        //    stream.Close();
        //    client.Close();
        //    listener.Stop();
        //}
        private static readonly object _lock = new object();
        private static readonly List<TcpClient> _clients = new List<TcpClient>();
        private static EventWaitHandle _closeApp = new(false, EventResetMode.ManualReset);
        private static IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
        private static int port = 12345;
        private static TcpListener listener = new TcpListener(ipAddress, port);

        public void StartServer()
        {
            listener.Start();
            Console.WriteLine("Server working...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("New Client");

                lock (_lock)
                {
                    _clients.Add(client);
                }

                Thread clientThread = new Thread(() => ClientHendler.ProcessClient(client));
                clientThread.Start();
            }
        }
        public void StopServer()
        {

            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            string response = "Hello from the server!";
            byte[] responseData = Encoding.ASCII.GetBytes(response);
            stream.Write(responseData, 0, responseData.Length);
            stream.Close();
            client.Close();
            listener.Stop();
            _closeApp.Set();
        }
    }
}
