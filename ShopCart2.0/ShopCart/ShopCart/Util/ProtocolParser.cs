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
        string _buffer = "";

        public string[] Parse(string buffer)
        {
            _buffer += buffer;

            string[] lines = _buffer.Split("\n");
            string[] result = Array.Empty<string>();

            if (lines.Length > 0)
            {
                _buffer = lines.Last();
                Array.Copy(lines, result, lines.Length - 1);
            }

            return result;
        }
    }
}
