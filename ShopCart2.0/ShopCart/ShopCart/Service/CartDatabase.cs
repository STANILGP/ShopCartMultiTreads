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
        List<Product> _products;
        public CartDatabase(Application _app) 
        {
            app= _app;
            _shopCartItems = app.LShopCartItems();
            _products = app.LProduct();
        }
        public void AddCartItem(uint productID, uint Quantity)
        {
            ShopCartItem item = new ShopCartItem();
            item.Id = (uint)_shopCartItems.Count;
            item.ProductId = productID;
            item.Quantity = Quantity;
            _shopCartItems.Add(item);
        }

        public void CheckOut()
        {
            double sum = 0;

            foreach (ShopCartItem item in _shopCartItems)
            {
                uint ProductId = (uint)item.Id;
               Product product = _products.Find(p => p.Id == ProductId);
                sum += item.Quantity * product.Price;
                product.Quantity -= item.Quantity;
            }
            Console.WriteLine(sum);
            _shopCartItems.Clear();
        }

        public void EditCartItem(uint productId)
        {
            ShopCartItem editProduct = _shopCartItems.Find(p => p.Id == productId);
            Console.WriteLine(editProduct.ToString());
            Console.WriteLine("New Quantity: ");
            int newQuantity = int.Parse(Console.ReadLine());
            editProduct.Quantity = (uint)newQuantity;
        }

        public void ListProduct()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine(product);
            }
        }

        public void RemoveCartItem(uint productId)
        {
           ShopCartItem removeItem = _shopCartItems.Find(p => p.Id == productId);
            if (removeItem != null)
            {
                _shopCartItems.Remove(removeItem);
                Console.WriteLine("Item is removed.");
            }
            else
            {
                Console.WriteLine("Item is not found.");
            }
        }

        public void SearchProduct(string name)
        {
            Product searchProduct = _products.Find(p => p.Name == name);
            if (searchProduct != null)
            {
                Console.WriteLine(searchProduct.ToString());
            }
            else
            {
                Console.WriteLine("Product is not found.");
            }
        }
    }
}
