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
        public List<Product> _products;
        public User user;// = new User();
        public int a = 0;
        public CartDatabase(Application _app,User _user) 
        {
            app= _app;
            _products = app.GetProductL();
             user = _user;
        }
        public void AddCartItem(uint productID, uint Quantity)
        {
            ShopCartItem item = new ShopCartItem();
            item.Id = (uint)a+1;
            item.ProductId = productID;
            item.Quantity = Quantity;
            user.Items.Add(item);
            a++;
        }

        public void CheckOut()
        {
            try
            {
                double sum = 0;

                foreach (ShopCartItem item in user.Items)
                {
                    uint ProductId = (uint)item.ProductId;
                    Product product = new Product();
                    product= _products.Find(p => p.Id == ProductId);
                    if (product == null)
                    {
                        throw new Exception("The item was not found .");
                    }

                    sum += item.Quantity * product.Price;
                    product.Quantity -= item.Quantity;
                    if (product.Quantity < 0)
                    {
                        throw new Exception("There are no items available for this item " + product.Name);
                        break;
                    }
                }
                user.Items.Clear();
                throw new Exception("Sum: " + sum);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
        }

        public void EditCartItem(uint productId,uint newQuantity)
        {
            ShopCartItem editProduct = user.Items.Find(p => p.Id == productId);
            Console.WriteLine(editProduct.ToString());
            editProduct.Quantity = (uint)newQuantity;
        }

        public string ListProducts()
        {
            string a = null;
            if (_products != null)
            {
                foreach (Product product in _products)
                {
                    a = a + "\n " + product.ToString();
                }
            }
            else
            {
                a = "We have 0 products";
            }
            return a;
        }
        public string ListCartItem()
        {
            string a = null;
            if (_products != null)
            {
                foreach (ShopCartItem cartitem in user.Items)
                {
                    a = a + "\n " + cartitem.ToString();
                }
            }
            else
            {
                a = "You have 0 Items";
            }
            return a;
        }
        public void RemoveCartItem(uint productId)
        {
            try
            { 
                  ShopCartItem removeItem = user.Items.Find(p => p.Id == productId);
                  if (removeItem != null)
                  {
                       user.Items.Remove(removeItem);
                       throw new Exception("Item is removed.");
                  }
                  else
                  {
                        throw new Exception("Item is not found.");
                  }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void SearchProduct(string name)
        {
            try
            {
                Product searchProduct = _products.Find(p => p.Name == name);
                if (searchProduct != null)
                {
                    Console.WriteLine(searchProduct.ToString());
                }
                else
                {
                    throw new Exception("Product is not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
