﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Service
{
    internal interface IDatabaseService
    {
        void Read(string filename);
        void Save();
        public void AddProduct(string name, string des, float price, uint quantity); 
        public void DeleteProduct(uint id);
        public void UpdateProduct(uint id);
        public void ListProducts();
        public void SearchProducts(string name);
    }
}
