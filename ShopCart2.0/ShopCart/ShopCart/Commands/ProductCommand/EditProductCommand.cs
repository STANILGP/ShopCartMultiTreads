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
    public class EditProductCommand : ICommandHandler
    {
        private IApplication _application;
        public EditProductCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            uint id = (uint)args.AsNumber(0);
            string editcom=args.AsString(1);
            string newArg=args.AsString(2);
            _application.GetDatabaseService().UpdateProduct(id, editcom, newArg);

        }

        public string GetHelp()
        {
            return "EditProduct({ID})";
        }

        public string GetName()
        {
           return "EditProduct";
        }
        public string Mess()
        {
            return "You change the product";
        }
    }
}
