using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ShopCart.ClientHandler
{
    internal class ClientHandler
    {
        

        static void Main(string[] args)
        {
            IPAddress serverIpAddress = IPAddress.Parse("127.0.0.1");
            int serverPort = 12345;
            TcpClient client = new TcpClient();
            client.Connect(serverIpAddress, serverPort);
            NetworkStream stream = client.GetStream();
            Console.WriteLine("Please enter command or help() for list of commands.");

            while (true)
            {
            
                Console.Write("> ");
                string? commandLine = Console.ReadLine();
                if (commandLine != null)
                {
                    byte[] data = Encoding.ASCII.GetBytes(commandLine);
                    stream.Write(data, 0, data.Length);
                }
            }
            stream.Close();
            client.Close();
        }
    }
}
