using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopCart.Commands.Product
{
    internal class EditProductCommand : ICommandHandler
    {
        private IApplication _application;
        public EditProductCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            uint id = (uint)args.AsNumber(3);
            _application.GetDatabaseService().UpdateProduct(id);
        }

        public string GetHelp()
        {
            return "EditProduct({ID})";
        }

        public string GetName()
        {
           return "EditProduct";
        }
    }
}
