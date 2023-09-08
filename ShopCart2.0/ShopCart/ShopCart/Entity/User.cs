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
    public class User
    {
        ProtocolParser _protocolParser = new ProtocolParser();
        public TcpClient? Client { get; set; }
        public UserRole Role { get; set; }
        public List<ShopCartItem> Items { get; set; } = new List<ShopCartItem>();
        public void AddUsers(TcpClient? client, UserRole role)
        {
            client = Client;
            role = Role;
        }
       
    }
}
