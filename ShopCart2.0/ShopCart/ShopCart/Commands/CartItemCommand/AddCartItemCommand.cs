using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.CartItem
{
    internal class AddCartItemCommand : ICommandHandler
    {
        private IApplication _application;

        public AddCartItemCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            int id = args.AsNumber(0);
            int Q = args.AsNumber(1);
           // _application.GetCartDatabase.AddCartItem(id, Q);
        }

        public string GetHelp()
        {
            return "AddCartItem({ProductID},{Quantity})";
        }

        public string GetName()
        {
            return "AddCartItem";
        }
    }
}
