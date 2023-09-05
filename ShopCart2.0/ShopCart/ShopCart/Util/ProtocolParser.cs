using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Util
{
    public class ProtocolParser
    {
        
        public List<string> Parse(string buffer)
        {
            string _buffer = "";
            _buffer += buffer;
            string[] lines = _buffer.Split("\n");
            _buffer = lines[lines.Length - 1];

            List<string> result = new List<string>(lines.Length - 1);
            for (int i = 0; i < lines.Length ; i++)
            {
                result.Add(lines[i]);
            }

            return result;
        }
    }
}
