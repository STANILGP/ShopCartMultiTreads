﻿using ShopCart.Commands;
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
    internal class ShopServer
    {
        private static readonly object _lock = new object();
        private static string? message;
        private static EventWaitHandle _closeApp = new(false, EventResetMode.ManualReset);
        private static IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
        private static int port = 12345;
        private static TcpListener listener = new TcpListener(ipAddress, port);
        private static List<User> userL = new List<User>();
        private UserRole UserRole=UserRole.None;
        private int NextUserID = 0;
        private static IApplication app = new Application();
        public static User user = new User();
        private static ProtocolParser _protocolParser = new ProtocolParser();
        private static List<string> mess = new();
        public void StartServer()
        {
            listener.Start();
            Console.WriteLine("Server working...");
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                //if (!listener.Pending())
                Console.WriteLine("New Client");

                lock (_lock)
                {
                    user.AddUsers(client,NextUserID,UserRole);
                    userL.Add(user);
                    NextUserID++;
                }
                Thread clientThread = new Thread(() => ProcessClient(client, user));
                clientThread.Start(); 
            }
        }
        public static void ProcessClient(TcpClient client, User user)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
               
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {     //0
                    message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received: " + message);
                    app.Run(user, _protocolParser.Parse(message));
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
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            stream.Close();
            client.Close();
            listener.Stop();
            _closeApp.Set();
        }
    }
}