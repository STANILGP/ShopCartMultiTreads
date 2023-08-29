using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    internal interface IDatabaseService
    {
        void Init();
        void Cleanup();

        public void AddProduct(string name, string des, float price, uint quantity); 
        public void DeleteProduct();
        public void UpdateProduct();
        public void ListProducts();
        public void SearchProducts();
    }
}
