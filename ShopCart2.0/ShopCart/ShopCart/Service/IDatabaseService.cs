using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    public interface IDatabaseService
    {
        void Read();
        void Save();
        public void AddProduct(string name, string des, float price, uint quantity); 
        public void DeleteProduct(uint id);
        public void UpdateProduct(uint id, string editcom, string newArg);
        public string ListProducts();
        public void SearchProducts(string name);
    }
}
