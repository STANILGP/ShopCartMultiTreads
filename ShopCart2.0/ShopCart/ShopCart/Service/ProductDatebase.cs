using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    internal class ProductDatebase :Product, IDatabaseService
    {
        private Application app;
        List<Product> _products;
        public ProductDatebase(Application _app)
        {
            app = _app;
            _products = app.LProduct();
        }
        public void AddProduct(string name, string des, float price, uint quantity)
        {
            Product product = new Product();
            product.Id = (uint)_products.Count();
            product.Name = name;
            product.Description = des;
            product.Price = price;
            product.Quantity = quantity;
            _products.Add(product);
        }

        public void Cleanup()
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void ListProducts()
        {
            throw new NotImplementedException();
        }

        public void SearchProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
