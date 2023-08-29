using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ShopCart.Commands.Product
{
    internal class AddProductCommand : ICommandHandler
    {
        private IApplication _application;
        public AddProductCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            string name = args.AsString(0);
            string description = args.AsString(1);
            float price = args.AsDecimal(2);
            uint quantity = (uint)args.AsNumber(3);
            _application.GetDatabaseService().AddProduct(name,description,price,quantity);
            Console.WriteLine($"You add {name} in Product List");
        }

        public string GetHelp()
        {
            return "AddProduct({Name},{Description},{Price},{Quantity})";
        }

        public string GetName()
        {
            return "AddProduct";
        }
    }
}
