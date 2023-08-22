using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Util
{
    internal class ProtocolParser
    {
        public string  sProtocolParser(NetworkStream stream) 
        {
            
            byte[] data = new byte[1024];
            int bytesRead = stream.Read(data, 0, data.Length);
            string message = Encoding.ASCII.GetString(data, 0, bytesRead);
            stream.Close();
            return message;
        }
    }
}
