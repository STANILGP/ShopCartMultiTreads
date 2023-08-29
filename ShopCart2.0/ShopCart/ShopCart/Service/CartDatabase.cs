using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    internal class CartDatabase :ShopCartItem, ICartDatabase
    {
        private Application app;
        List<ShopCartItem> _shopCartItems;  
        public CartDatabase(Application _app) 
        {
            app= _app;
            _shopCartItems = app.LShopCartItems();
        }
        public void AddCartItem(uint productID, uint Quantity)
        {
            ShopCartItem item = new ShopCartItem();
            item.Id = (uint)_shopCartItems.Count;
            item.ProductId = productID;
            item.Quantity = Quantity;
            _shopCartItems.Add(item);
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
