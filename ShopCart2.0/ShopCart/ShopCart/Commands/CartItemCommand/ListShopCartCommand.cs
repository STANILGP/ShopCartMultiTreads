using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.CartItemCommand
{
    internal class ListShopCartCommand : ICommandHandler
    {
        private IApplication _application;
        public ListShopCartCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            _application.GetCartDatabase().ListCartItem();
        }

        public string GetHelp()
        {
            return "ListCartItem()";
        }

        public string GetName()
        {
            return "ListCartItem";
        }
        public string Mess()
        {
            return _application.GetCartDatabase().ListCartItem();
        }
    }
}
