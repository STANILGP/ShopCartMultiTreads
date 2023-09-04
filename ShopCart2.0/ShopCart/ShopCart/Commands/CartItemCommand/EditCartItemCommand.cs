using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.CartItem
{
    internal class EditCartItemCommand : ICommandHandler
    {
        private IApplication _application;
        public EditCartItemCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            uint itemId = (uint)args.AsNumber(0);
            uint quantity= (uint)args.AsNumber(1);
            _application.GetCartDatabase().EditCartItem(itemId,quantity);
        }

        public string GetHelp()
        {
            return "EditShopCart({Id})";
        }

        public string GetName()
        {
           return "EditShopCart";
        }
        public string Mess()
        {
            return "You change quantity";
        }
    }
}
