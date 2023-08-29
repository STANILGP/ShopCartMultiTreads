using ShopCart.Entity;
using System;
using System.Collections.Generic;
using System.Data;
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
            Product removeproduct = _products.Find(p => p.Id == id);
            if (removeproduct != null)
            {
                _products.Remove(removeproduct);
                Console.WriteLine("Product is removed.");
            }
            else
            {
                Console.WriteLine("Product is not found.");
            }
        }

        public void Read(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null /*|| (line = sr.ReadLine()) != ""*/)
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
        public void ListProducts()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine(product);
            }
        }

        public void SearchProducts(string name)
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

        public void UpdateProduct(uint id)
        {
            Product editProduct = _products.Find(p => p.Id == id);
            Console.WriteLine(editProduct.ToString());
            string? editcom = Console.ReadLine();
            
                Console.WriteLine("What you will edit?");
                Console.WriteLine("Name/Description/Price/Quantity");
                if (editcom == "Name")
                {
                    Console.WriteLine("New Name:");
                    string? editName = Console.ReadLine();
                    editProduct.Name = editName;
                }

                else if (editcom == "Description")
                {
                    Console.WriteLine("New Description:");
                    string? editDiscription = Console.ReadLine();
                    editProduct.Description = editDiscription;
                }

                else if (editcom == "Price")
                {
                    Console.WriteLine("New Price:");
                    float editPrice = float.Parse(Console.ReadLine());
                    editProduct.Price = editPrice;
                }

                else if (editcom == "Quantity")
                {
                    Console.WriteLine("New Quantity:");
                    uint editQuantity = uint.Parse(Console.ReadLine());
                    editProduct.Quantity = editQuantity;
                }

                else
                {
                    Console.WriteLine("Error");
                }
            
        

    }
}
}
