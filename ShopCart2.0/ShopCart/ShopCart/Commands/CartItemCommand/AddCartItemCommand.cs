using ShopCart.Entity;
using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopCart.Commands.CartItem
{
    public class AddCartItemCommand : ICommandHandler
    {
        private IApplication _application;

        public AddCartItemCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            uint ProductId = (uint)args.AsNumber(0);
            uint Q = (uint)args.AsNumber(1);
            _application.GetCartDatabase().AddCartItem(ProductId,Q);
        }

        public string GetHelp()
        {
            return "AddCartItem({ProductID},{Quantity})";
        }

        public string GetName()
        {
            return "AddCartItem";
        }
        public string Mess()
        {
            return "You add item in you cart";
        }
    }
}
