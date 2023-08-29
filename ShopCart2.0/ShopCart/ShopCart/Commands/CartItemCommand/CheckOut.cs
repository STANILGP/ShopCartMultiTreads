using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.CartItemCommand
{
    internal class CheckOut : ICommandHandler
    {
        private IApplication _application;

        public CheckOut(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            _application.GetCartDatabase().CheckOut();
        }

        public string GetHelp()
        {
            return "CheckOut()";
        }

        public string GetName()
        {
           return "CheckOut";
        }
    }
}
