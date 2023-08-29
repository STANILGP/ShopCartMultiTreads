using ShopCart.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Entity
{
    internal class User
    {
        ProtocolParser _protocolParser = new ProtocolParser();
        public TcpClient? Client { get; set; }
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public void AddUsers(TcpClient? client, int br, UserRole role)
        {
            client = Client;
            br = Id;
            role = Role;
        }
       
    }
}
