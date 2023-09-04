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
        public void EditCartItem(uint productID, uint quantity);
        public void SearchProduct(string name);
        public string ListProducts();
        public string ListCartItem();

        public void CheckOut();

    }
}
