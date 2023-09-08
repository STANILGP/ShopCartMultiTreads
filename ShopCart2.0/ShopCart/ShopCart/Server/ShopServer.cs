using ShopCart.Commands;
using ShopCart.Entity;
using ShopCart.Service;
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
    public class ShopServer
    {
        private readonly object _lock = new object();  
        private EventWaitHandle _closeApp = new(false, EventResetMode.ManualReset);
        public static IPAddress _address= IPAddress.Parse("0.0.0.0");
        private TcpListener listener = new TcpListener(_address, 12345);
        private  List<User> userL = new List<User>();

        public void StartServer()
        {
            listener.Start();
            Console.WriteLine("Server working...");
            List<Thread> clientThreads = new List<Thread>();
            while (!_closeApp.WaitOne(0))
            {
                if(!listener.Pending())
                {
                    Thread.Sleep(10);
                    continue;
                    
                }
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("New Client");
                User user = new User();
                IApplication app = new Application();
                lock (_lock)
                {
                    user.AddUsers(client, UserRole.None);
                    userL.Add(user);
                }
                Thread clientThread = new Thread(() => ProcessClient(client, user,app));
                clientThreads.Add(clientThread);
                clientThread.Start();
                if (!client.Connected)
                { 
                    clientThread.Join();
                }
                
            }
            foreach (Thread clientThread in clientThreads)
            {
                clientThread.Join();
            }
        }
        public void ProcessClient(TcpClient client, User user,IApplication app)
        {
            using (NetworkStream stream = client.GetStream())
            {
                if (client.Connected)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        Console.WriteLine("Received: " + message);
                        string r = app.Run(user, message);
                        Notification.SendMessageToClient(client, r);
                    }
                    
                }
                Console.WriteLine("Client off.");
                lock (_lock)
                {
                    userL.Remove(user);
                }
                client.Close();
                
            }
        }
        public void StopServer()
        {
            listener.Stop();
            _closeApp.Set();
        }
    }
}