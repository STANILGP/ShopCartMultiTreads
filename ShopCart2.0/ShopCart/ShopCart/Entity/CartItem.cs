﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Entity
{
    internal class CartItem
    {
        public uint Id { get; set; }
        public uint ProductId { get; set; }
        public uint Quantity { get; set; }
    }
}