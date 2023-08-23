using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Server
{
    internal class ClientHendler
    {
        private static readonly object _lock = new object();
        private static readonly List<TcpClient> _clients = new List<TcpClient>();

        public static void ProcessClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Sent: " + message);

                    //BroadcastMessage.BroadcastMessagee(message, client);
                }

                Console.WriteLine("Client off.");
                lock (_lock)
                {
                    _clients.Remove(client);
                }
                client.Close();
            }
        }
    }
}
