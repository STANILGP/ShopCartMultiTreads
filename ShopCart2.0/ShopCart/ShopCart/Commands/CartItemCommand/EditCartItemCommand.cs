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
            _application.GetCartDatabase().EditCartItem(itemId);
        }

        public string GetHelp()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
