using ShopCart.Entity;
using ShopCart.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    public class ProductDatebase : Product, IDatabaseService
    {
        private Application app;
        private List<Product> _products = new List<Product>();
        public ProductDatebase(Application _app)
        {
            app = _app;
            _products = app.GetProductL();
        }

        public void AddProduct(string name, string des, float price, uint quantity)
        {
            Product product = new Product();
            product.Id = (uint)_products.Count + 1;
            product.Name = name;
            product.Price = price;
            product.Quantity= quantity;
            product.Description = des;
            _products.Add(product);
        }

        public void Save()
        {
            string filename = "Product.txt";
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Product field in _products)
                {
                    writer.WriteLine(field.ToString());
                }
            }
        }

        public void DeleteProduct(uint id)
        {
            try
            {
                Product removeproduct = _products.Find(p => p.Id == id);
                if (removeproduct != null)
                {
                    _products.Remove(removeproduct);
                    throw new Exception("Product is removed.");
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

        public void Read()
        {
            string filename = "Product.txt";
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null && line!="")
                {
                    string[] parts = line.Split('*');
                    uint id = uint.Parse(parts[1]);
                    string name = parts[2].Trim();
                    string description = parts[3].Trim(); ;
                    float price = float.Parse(parts[4].Trim());
                    uint Quantity = uint.Parse(parts[5].Trim());
                    _products.Add(new Product { Id = (uint)id, Name = name, Description = description, Price = price, Quantity = Quantity });
                }
            }

        }
        public string ListProducts()
        {
            string a=null;
            if (_products != null)
            {
                foreach (Product product in _products)
                {
                 a =a+ "\n "+product.ToString();
                }
            }
            else
            {
               a= "We have 0 products";
            }
            return a;
        }

        public void SearchProducts(string name)
        {
            try
            {
                Product searchProduct = _products.Find(p => p.Name == name);
                if (searchProduct != null)
                {
                    throw new Exception(searchProduct.ToString());
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

        public void UpdateProduct(uint id,string editcom,string newArg )
        {
            try
            {
                Product editProduct = new();
                editProduct = _products.Find(p => p.Id == id);

                if (editcom == "Name")
                {
                    editProduct.Name = newArg;
                }

                else if (editcom == "Description")
                {
                    editProduct.Description = newArg;
                }

                else if (editcom == "Price")
                {
                    editProduct.Price = float.Parse(newArg);
                }

                else if (editcom == "Quantity")
                {
                    editProduct.Quantity = uint.Parse(newArg);
                }

                else
                {
                    throw new Exception("Error");
                }


                throw new Exception(_products.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
