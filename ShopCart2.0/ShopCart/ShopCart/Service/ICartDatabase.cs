using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    internal interface ICartDatabase 
    {
        public void AddCartItem(uint productID,uint Quantity);
        public void RemoveCartItem(uint productID);
        public void EditCartItem(uint productID);
        public void SearchProduct(string name);
        public void ListProduct();
        public void CheckOut();

    }
}
