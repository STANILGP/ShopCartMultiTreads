using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Server
{
    internal class Notification
    {
        public static void SendMessageToClient(TcpClient client, string message)
        {
            if (client != null && client != null)
            {
                try
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(message);
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending message to client: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid user or client is null.");
            }
        }
    }
}
