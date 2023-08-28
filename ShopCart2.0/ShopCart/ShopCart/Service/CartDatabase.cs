using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    internal class CartDatabase : CartItem , ICartDatabase
    {
        public void AddCartItem(uint ID,uint ProductId,uint Quantity)
        {
            
        }

        public void EditCartItem()
        {
            throw new NotImplementedException();
        }

        public void ListProduct()
        {
            throw new NotImplementedException();
        }

        public void RemoveCartItem()
        {
            throw new NotImplementedException();
        }

        public void SearchProduct()
        {
            throw new NotImplementedException();
        }
    }
}
