using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Entity
{
    internal class Product
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public uint Quantity { get; set; }
        public float Price { get; set; }
        public override string ToString()
        {

            return $"*{Id}*{Name}*{Description}*{Price}*{Quantity}*";
        }
    }
}
