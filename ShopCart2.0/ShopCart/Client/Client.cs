using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Client
{
    internal class Client
    {
        static void Main(string[] args)
        {
            IPAddress serverIpAddress = IPAddress.Parse("127.0.0.1");
            int serverPort = 12345;
            TcpClient client = new TcpClient();
            client.Connect(serverIpAddress, serverPort);
            NetworkStream stream = client.GetStream();
            Console.WriteLine("Please enter command or help() for list of commands.");

            try
            {
                Task.Run(() => ReceiveMessages(stream)); 
                while (true)
                {
                    string? commandLine = Console.ReadLine();
                    if (commandLine != null)
                    {
                        byte[] data = Encoding.ASCII.GetBytes(commandLine);
                        stream.Write(data, 0, data.Length);
                    } 
                }
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }

        static async Task ReceiveMessages(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine(message);
                }
            }
        }
    }
}
