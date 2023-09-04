using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.Product
{
    internal class RemoveProductCommand : ICommandHandler
    {
        private IApplication _application;
        public RemoveProductCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            uint id = (uint)args.AsNumber(0);
            _application.GetDatabaseService().DeleteProduct(id);
        }

        public string GetHelp()
        {
           return "RemoveProduct({Id})";
        }

        public string GetName()
        {
            return "RemoveProduct";
        }
        public string Mess()
        {
            return "Product was remove";
        }
    }
}
