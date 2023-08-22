using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    internal interface ICartDatabase
    {
        public void AddCartItem();
        public void RemoveCartItem();
        public void EditCartItem();
        public void SearchProduct();
        public void ListProduct();
    }
}
