using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.Product
{
    internal class AddProductCommand : ICommandHandler
    {

        public void Execute(CommandArguments args)
        {
            throw new NotImplementedException();
        }

        public string GetHelp()
        {
            return "AddProduct command help string";
        }

        public string GetName()
        {
            return "AddProduct";
        }
    }
}
