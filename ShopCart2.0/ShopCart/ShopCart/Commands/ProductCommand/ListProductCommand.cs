using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.ProductCommand
{
    public class ListProductCommand : ICommandHandler
    {
        private IApplication _application;
        public ListProductCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            _application.GetDatabaseService().ListProducts();
            _application.GetCartDatabase().ListProducts();
        }
        public string GetHelp()
        {
           return "ListProduct()";
        }
        public string GetName()
        {
            return "ListProduct";
        }
        public string Mess()
        {
            return _application.GetDatabaseService().ListProducts();
        }
    }
}
