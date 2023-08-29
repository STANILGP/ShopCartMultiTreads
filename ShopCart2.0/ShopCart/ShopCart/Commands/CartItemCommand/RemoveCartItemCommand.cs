using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.CartItem
{
    internal class RemoveCartItemCommand : ICommandHandler
    {
        private IApplication _application;
        public RemoveCartItemCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            uint id = (uint)args.AsNumber(0);
            _application.GetCartDatabase().EditCartItem(id);
        }

        public string GetHelp()
        {
            return "RemoveCartItem({Id})";
        }

        public string GetName()
        {
            return "RemoveCartItem";
        }
    }
}
