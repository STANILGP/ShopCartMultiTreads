using ShopCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Commands.ProductCommand
{
    internal class SearchProductCommand : ICommandHandler
    {
        private IApplication _application;
        public SearchProductCommand(IApplication application)
        {
            _application = application;
        }
        public void Execute(CommandArguments args)
        {
            string name = args.AsString(0);
            _application.GetDatabaseService().SearchProducts(name);
        }

        public string GetHelp()
        {
            return "Search({Name})";
        }

        public string GetName()
        {
            return "Search";
        }
    }
}
